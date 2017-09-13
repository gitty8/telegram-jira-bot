// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Jira.Models;

namespace Telegram.Bot.Jira.Converters
{
    public class IssueFieldJsonConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jtoken = JToken.ReadFrom(reader);
            var fields = new Fields();
            var jproperty = (JProperty) jtoken.Children().First();
            var dictionary = new Dictionary<string, PropertyInfo>();
            foreach (var property in typeof(Fields).GetTypeInfo().GetProperties())
            {
                var customAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                if (customAttribute != null)
                    dictionary[customAttribute.PropertyName] = property;
            }
            while (jproperty != null)
            {
                var name = jproperty.Name;
                if (!dictionary.TryGetValue(name, out var propertyInfo))
                {
                    fields.Other.Add(name, jproperty.Value);
                }
                else
                {
                    var obj = jproperty.Value.ToObject(propertyInfo.PropertyType, serializer);
                    propertyInfo.SetValue(fields, obj);
                }
                jproperty = (JProperty) jproperty.Next;
            }

            return fields;
        }


        public override bool CanConvert(Type objectType)
        {
            return typeof(Fields).GetTypeInfo().IsAssignableFrom(objectType);
        }
    }
}