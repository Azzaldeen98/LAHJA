﻿using System.Collections.Generic;

namespace LAHJA.Data.UI.Components.ServiceCard
{

    public class ModelProperties
    {
        public string Type { get; set; }
        public string Voice { get; set; }
        public string Language { get; set; }
        public string Dialect { get; set; }
        public string Token { get; set; }
        public string Quality { get; set; }
        public string ModelVersion { get; set; }
        public string CreationDate { get; set; }
        public string LastUpdated { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Accuracy { get; set; }
        public string Speed { get; set; }
        public string Framework { get; set; }
        public string Parameters { get; set; }
        public string ModelImageUrl { get; set; }
        public string UsageCount { get; set; }
 
    }

    public class PropertyGenerator
    {
        public static Dictionary<string, List<string>> propertyValues = new Dictionary<string, List<string>>()
    {
        { "UsageCount", new List<string> { "600","8888" } },
        { "ModelImageUrl", new List<string> { "/ai-hand.png", "/ai-robot.png", "chat-boat.jpg", "chatbot-cta.png" } },
        { "Type", new List<string> { "Text To Text", "Text To Speech", "Chat Model" } },
        { "Voice", new List<string> { "Male", "Female" } },
        { "Language", new List<string> { "English", "Spanish", "French", "German", "Arabic" } },
        { "Dialect", new List<string> { "American", "British", "Australian" ,"Najd","Hijazi"} },
        { "Quality", new List<string> { "High", "Medium", "Low" } },
        { "Token", new List<string> { "100", "500", "1000", "5000", "10000" } },
        { "ModelVersion", new List<string> { "v1.0", "v1.1", "v2.0", "v2.5", "v3.0" } },
        { "CreationDate", new List<string> { "2023-01-01", "2022-12-15", "2021-11-20" } },
        { "LastUpdated", new List<string> { "2023-12-01", "2023-11-15", "2023-10-30" } },
        { "Description", new List<string> { "Random generated description.", "High-quality model for tasks.", "Used in various applications." } },
        { "Author", new List<string> { "Author 1", "Author 2", "Author 3" } },
        { "Accuracy", new List<string> { "0.90", "0.85", "0.95" } },
        { "Speed", new List<string> { "Fast", "Medium", "Slow" } },
        { "Framework", new List<string> { "TensorFlow", "PyTorch", "Keras" } },
        { "Parameters", new List<string> { "1000000", "5000000", "10000000" } }
    };




 public static  Dictionary<string, List<string>> propertyValuesInArabic = new Dictionary<string, List<string>>()
{
    { "UsageCount", new List<string> { "600", "8888" } },
    { "ModelImageUrl", new List<string> { "/ai-hand.png", "/ai-robot.png", "chat-boat.jpg", "chatbot-cta.png" } },
    { "Type", new List<string> { "نص إلى نص", "نص إلى كلام", "نموذج محادثة" } },
    { "Voice", new List<string> { "ذكر", "أنثى" } },
    { "Language", new List<string> { "إنجليزي", "إسباني", "فرنسي", "ألماني", "عربي" } },
    { "Dialect", new List<string> { "أمريكي", "بريطاني", "أسترالي", "نجدي","حجازي" } },
    { "Quality", new List<string> { "عالي", "متوسط", "منخفض" } },
    { "Token", new List<string> { "100", "500", "1000", "5000", "10000" } },
    { "ModelVersion", new List<string> { "v1.0", "v1.1", "v2.0", "v2.5", "v3.0" } },
    { "CreationDate", new List<string> { "2023-01-01", "2022-12-15", "2021-11-20" } },
    { "LastUpdated", new List<string> { "2023-12-01", "2023-11-15", "2023-10-30" } },
    { "Description", new List<string> { "وصف تم إنشاؤه عشوائيًا.", "نموذج عالي الجودة للمهام.", "يستخدم في العديد من التطبيقات." } },
    { "Author", new List<string> { "المؤلف 1", "المؤلف 2", "المؤلف 3" } },
    { "Accuracy", new List<string> { "0.90", "0.85", "0.95" } },
    { "Speed", new List<string> { "سريع", "متوسط", "بطيء" } },
    { "Framework", new List<string> { "TensorFlow", "PyTorch", "Keras" } },
    { "Parameters", new List<string> { "1000000", "5000000", "10000000" } }
};

        private static Random random = new Random();


        public static List<ModelProperties> GenerateModelPropertiesList(int count,int type)
        {



            List<ModelProperties> modelPropertiesList = new List<ModelProperties>();

            for (int i = 0; i < count; i++)
            {

                var modelProperties = new ModelProperties
                {
                    Type = GetRandomValue("Type", type),
                    Voice = GetRandomValue("Voice", type),
                    Language = GetRandomValue("Language", type),
                    Dialect = GetRandomValue("Dialect", type),
                    Token =GetRandomValue("Token", type),
                    Quality = GetRandomValue("Quality", type),
                    ModelVersion = GetRandomValue("ModelVersion", type),
                    CreationDate = GetRandomValue("CreationDate", type),
                    LastUpdated = GetRandomValue("LastUpdated", type),
                    Description = GetRandomValue("Description", type),
                    Author = GetRandomValue("Author", type),
                    Accuracy =GetRandomValue("Accuracy", type),
                    Speed =GetRandomValue("Speed", type),
                    Framework = GetRandomValue("Framework", type),
                    Parameters =GetRandomValue("Parameters", type),
                    ModelImageUrl = GetRandomValue("ModelImageUrl", type),
                    UsageCount = GetRandomValue("UsageCount", type)
             
                };

                modelPropertiesList.Add(modelProperties);
            }

            return modelPropertiesList;
        }

        private static string GetRandomValue(string key,int type)
        {

            if (type == 0)
            {
                var values = propertyValues[key];
                return values[random.Next(values.Count)];
            }
            else
            {
                var values = propertyValuesInArabic[key];
                return values[random.Next(values.Count)];
            }
         
        }

        
    }











}