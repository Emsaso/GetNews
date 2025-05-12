﻿
namespace GetNews.API.ApiModel
{
    public class EmailAddress
    {
        public string Value { get; }

        public EmailAddress(string value)
        {
            Value = value;
        }

        public bool IsValid()
        {
            return Value.Contains('@') && Value.Contains('.');
        }
    }
}
