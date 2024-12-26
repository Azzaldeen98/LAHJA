using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsPlansContainers
    {
      private static List<ContainerPlansModel> db= new List<ContainerPlansModel>();


        public SeedsPlansContainers()
        {

            db = SeedsPlansContainersAR();
            //db = SeedsPlansContainersEN();
        


         }

        public List<ContainerPlansModel> SeedsPlansContainersEN()
        {
            return new List<ContainerPlansModel>{
                new ContainerPlansModel
                {
                    Id = "1",
                    Name = "Basic Plan Container",
                    Description = "A container for basic subscription plans.",
                    Active = true,
                    Image = "basic-plan-container.png",
                    SubscriptionsPlans = new List<SubscriptionPlanModel>
                    {
                        new SubscriptionPlanModel
                        {
                            Id = "1",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                   new PlanFeatureModel { Id = "1", Name = "Text To Speech Service", Description = "Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, TotalAmount = 9.99m, Active = true },
                                    new PlanFeatureModel { Id = "2", Name = "Voice Quality", Description = "Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, TotalAmount = 29.99m, Active = true },
                                    new PlanFeatureModel { Id = "3", Name = "Voice Type", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true },
                                    new PlanFeatureModel { Id = "4", Name = "Support Types", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "5", Name = "Server Speeds", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "6", Name = "Server Voice", Description = "Basic Voice-to-Voice service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },


                                //new PlanFeatureModel { Id="1",Name = "Feature 1", Description = "Basic feature description.", },
                                //new PlanFeatureModel { Id="2",Name = "Feature 2", Description = "Another basic feature description." },
                                //new PlanFeatureModel { Id="3",Name = "Feature 3", Description = "Another basic feature description." },
                                //new PlanFeatureModel { Id="4",Name = "Feature 4", Description = "Another basic feature description.",IsFixed=false},
                                //new PlanFeatureModel { Id="5",Name = "Feature 5", Description = "Another basic feature description.",IsFixed=false},
                                //new PlanFeatureModel { Id="6",Name = "Feature 6", Description = "Another basic feature description.",IsFixed=false },
                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "2",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                    new PlanFeatureModel { Id = "1", Name = "Text To Speech Service", Description = "Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, TotalAmount = 9.99m, Active = true },
                                    new PlanFeatureModel { Id = "2", Name = "Voice Quality", Description = "Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, TotalAmount = 29.99m, Active = true },
                                    new PlanFeatureModel { Id = "3", Name = "Voice Type", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true },
                                    new PlanFeatureModel { Id = "4", Name = "Support Types", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "5", Name = "Server Speeds", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "6", Name = "Server Voice", Description = "Basic Voice-to-Voice service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },


                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "3",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                 new PlanFeatureModel { Id = "1", Name = "Text To Speech Service", Description = "Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, TotalAmount = 9.99m, Active = true },
                                    new PlanFeatureModel { Id = "2", Name = "Voice Quality", Description = "Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, TotalAmount = 29.99m, Active = true },
                                    new PlanFeatureModel { Id = "3", Name = "Voice Type", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true },
                                    new PlanFeatureModel { Id = "4", Name = "Support Types", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "5", Name = "Server Speeds", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "6", Name = "Server Voice", Description = "Basic Voice-to-Voice service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                            }
                        }
                    }
                },
                new ContainerPlansModel
                {
                    Id = "2",
                    Name = "Basic Plan Container",
                    Description = "A container for basic subscription plans.",
                    Active = true,
                    Image = "basic-plan-container.png",
                    SubscriptionsPlans = new List<SubscriptionPlanModel>
                    {
                        new SubscriptionPlanModel
                        {
                            Id = "1",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                     new PlanFeatureModel { Id = "1", Name = "Text To Speech Service", Description = "Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, TotalAmount = 9.99m, Active = true },
                                    new PlanFeatureModel { Id = "2", Name = "Voice Quality", Description = "Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, TotalAmount = 29.99m, Active = true },
                                    new PlanFeatureModel { Id = "3", Name = "Voice Type", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true },
                                    new PlanFeatureModel { Id = "4", Name = "Support Types", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "5", Name = "Server Speeds", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "6", Name = "Server Voice", Description = "Basic Voice-to-Voice service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "2",
                            Name = "Primum Plan",
                            Description = "A Primum subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                      new PlanFeatureModel { Id = "1", Name = "Text To Speech Service", Description = "Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, TotalAmount = 9.99m, Active = true },
                                    new PlanFeatureModel { Id = "2", Name = "Voice Quality", Description = "Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, TotalAmount = 29.99m, Active = true },
                                    new PlanFeatureModel { Id = "3", Name = "Voice Type", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true },
                                    new PlanFeatureModel { Id = "4", Name = "Support Types", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "5", Name = "Server Speeds", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "6", Name = "Server Voice", Description = "Basic Voice-to-Voice service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "3",
                            Name ="Speshial Plan Container",
                            Description = "A Speshial subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                  new PlanFeatureModel { Id = "1", Name = "Text To Speech Service", Description = "Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, TotalAmount = 9.99m, Active = true },
                                    new PlanFeatureModel { Id = "2", Name = "Voice Quality", Description = "Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, TotalAmount = 29.99m, Active = true },
                                    new PlanFeatureModel { Id = "3", Name = "Voice Type", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true },
                                    new PlanFeatureModel { Id = "4", Name = "Support Types", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "5", Name = "Server Speeds", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "6", Name = "Server Voice", Description = "Basic Voice-to-Voice service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                            }
                        }
                    }
                },
                new ContainerPlansModel
                {
                    Id = "3",
                    Name = "Premim Plan Container",
                    Description = "A container for basic subscription plans.",
                    Active = true,
                    Image = "basic-plan-container.png",
                    SubscriptionsPlans = new List<SubscriptionPlanModel>
                    {
                        new SubscriptionPlanModel
                        {
                            Id = "1",
                            Name = "Basic Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                    new PlanFeatureModel { Id = "1", Name = "Text To Speech Service", Description = "Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, TotalAmount = 9.99m, Active = true },
                                    new PlanFeatureModel { Id = "2", Name = "Voice Quality", Description = "Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, TotalAmount = 29.99m, Active = true },
                                    new PlanFeatureModel { Id = "3", Name = "Voice Type", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true },
                                    new PlanFeatureModel { Id = "4", Name = "Support Types", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "5", Name = "Server Speeds", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "6", Name = "Server Voice", Description = "Basic Voice-to-Voice service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "2",
                            Name = "Primum Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "Primum-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                                   new PlanFeatureModel { Id = "1", Name = "Text To Speech Service", Description = "Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, TotalAmount = 9.99m, Active = true },
                                    new PlanFeatureModel { Id = "2", Name = "Voice Quality", Description = "Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, TotalAmount = 29.99m, Active = true },
                                    new PlanFeatureModel { Id = "3", Name = "Voice Type", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true },
                                    new PlanFeatureModel { Id = "4", Name = "Support Types", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "5", Name = "Server Speeds", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "6", Name = "Server Voice", Description = "Basic Voice-to-Voice service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                            }
                        },
                        new SubscriptionPlanModel
                        {
                            Id = "3",
                            Name = "Professional Plan",
                            Description = "A simple subscription plan.",
                            Active = true,
                            Price = 9.99m,
                            IsFixed = false,
                            IsPaid = true,
                            Quantity = 1,
                            BillingPeriod = "Monthly",
                            TotalAmount = 9.99m,
                            ContainerId = "1",
                            TotalBilling = 119.88m,
                            Image = "basic-plan.png",
                            MonthlyPrice = 9.99m,
                            AnnualPrice = 99.99m,
                            WeeklyPrice = 2.49m,
                            Features = new List<PlanFeatureModel>
                            {
                           new PlanFeatureModel { Id = "1", Name = "Text To Speech Service", Description = "Basic text-to-speech service", BillingPeriod = "week", NumberRequests = 250, TotalAmount = 9.99m, Active = true },
                                    new PlanFeatureModel { Id = "2", Name = "Voice Quality", Description = "Basic text-to-speech service", BillingPeriod = "Monthly", NumberRequests = 3000, TotalAmount = 29.99m, Active = true },
                                    new PlanFeatureModel { Id = "3", Name = "Voice Type", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true },
                                    new PlanFeatureModel { Id = "4", Name = "Support Types", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "5", Name = "Server Speeds", Description = "Basic text-to-speech service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                                    new PlanFeatureModel { Id = "6", Name = "Server Voice", Description = "Basic Voice-to-Voice service", BillingPeriod = "Yearly", NumberRequests = 36000, TotalAmount = 299.99m, Active = true,IsFixed=false  },
                            }
                        }
                    }
                }
            };
        }
        public List<ContainerPlansModel> SeedsPlansContainersAR()
        {
            var plans = new List<SubscriptionPlanModel>
            {
                    new SubscriptionPlanModel
                    {
                        Id = "1",
                        Name = "الخطة العامة (Basic Plan)",
                        Description = "خطة اشتراك أساسية",
                        Active = true,
                        Price = 9.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 9.99m,
                        ContainerId = "1",
                        TotalBilling = 119.88m,
                        Image = "basic-plan.png",
                        MonthlyPrice = 9.99m,
                        AnnualPrice = 99.99m,
                        WeeklyPrice = 2.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "Requests", Description = "1,000 طلب", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "CPU", Description = "مشترك مع خوادم أخرى", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "RAM", Description = "4 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "Speed (Response Time)", Description = "متوسط 2 ثانية لكل طلب", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Support", Description = "دعم عبر البريد الإلكتروني فقط", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true }
                        }
                    },
                    new SubscriptionPlanModel
                    {
                        Id = "2",
                        Name = "الخطة المتوسطة (Standard Plan)",
                        Description = "خطة اشتراك متوسطة",
                        Active = true,
                        Price = 29.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 29.99m,
                        ContainerId = "2",
                        TotalBilling = 359.88m,
                        Image = "standard-plan.png",
                        MonthlyPrice = 29.99m,
                        AnnualPrice = 299.99m,
                        WeeklyPrice = 7.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "Requests", Description = "10,000 طلب", BillingPeriod = "Monthly", NumberRequests = 10000, TotalAmount = 29.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "CPU", Description = "معالج مستقل رباعي النواة", BillingPeriod = "Monthly", TotalAmount = 29.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "RAM", Description = "8 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 29.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "Customization", Description = "إمكانية تعديل نبرة الصوت وسرعته", BillingPeriod = "Monthly", TotalAmount = 29.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Support", Description = "دعم عبر البريد الإلكتروني والدردشة الفورية خلال ساعات العمل", BillingPeriod = "Monthly", TotalAmount = 29.99m, Active = true }
                        }
                    },
                    new SubscriptionPlanModel
                    {
                        Id = "3",
                        Name = "الخطة الاحترافية (Professional Plan)",
                        Description = "خطة اشتراك احترافية",
                        Active = true,
                        Price = 49.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 49.99m,
                        ContainerId = "3",
                        TotalBilling = 599.88m,
                        Image = "professional-plan.png",
                        MonthlyPrice = 49.99m,
                        AnnualPrice = 499.99m,
                        WeeklyPrice = 12.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "Requests", Description = "50,000 طلب", BillingPeriod = "Monthly", NumberRequests = 50000, TotalAmount = 49.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "CPU", Description = "معالج مستقل ثماني النواة", BillingPeriod = "Monthly", TotalAmount = 49.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "RAM", Description = "16 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 49.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "Customization", Description = "تخصيص كامل لتجربة الاستخدام", BillingPeriod = "Monthly", TotalAmount = 49.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Support", Description = "دعم فوري على مدار الساعة عبر البريد الإلكتروني والدردشة", BillingPeriod = "Monthly", TotalAmount = 49.99m, Active = true }
                        }
                    },
                     new SubscriptionPlanModel
    {
        Id = "4",
        Name = "الخطة المتقدمة (Advanced Plan)",
        Description = "خطة اشتراك متقدمة للمؤسسات",
        Active = true,
        Price = 99.99m,
        IsFixed = false,
        IsPaid = true,
        Quantity = 1,
        BillingPeriod = "Monthly",
        TotalAmount = 99.99m,
        ContainerId = "4",
        TotalBilling = 1199.88m,
        Image = "advanced-plan.png",
        MonthlyPrice = 99.99m,
        AnnualPrice = 999.99m,
        WeeklyPrice = 24.99m,
        Features = new List<PlanFeatureModel>
        {
            new PlanFeatureModel { Id = "1", Name = "Requests", Description = "100,000 طلب", BillingPeriod = "Monthly", NumberRequests = 100000, TotalAmount = 99.99m, Active = true },
            new PlanFeatureModel { Id = "2", Name = "CPU", Description = "معالج مستقل متعدد الأنوية", BillingPeriod = "Monthly", TotalAmount = 99.99m, Active = true },
            new PlanFeatureModel { Id = "3", Name = "RAM", Description = "32 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 99.99m, Active = true },
            new PlanFeatureModel { Id = "4", Name = "Customization", Description = "إعدادات متقدمة لتجربة الاستخدام", BillingPeriod = "Monthly", TotalAmount = 99.99m, Active = true },
            new PlanFeatureModel { Id = "5", Name = "Support", Description = "دعم فوري وشامل عبر جميع القنوات", BillingPeriod = "Monthly", TotalAmount = 99.99m, Active = true }
        }
    }
                // Add other plans similarly...
            }; ;
            return new List<ContainerPlansModel>
{
    new ContainerPlansModel
    {
        Id = "1",
        Name = "تحويل النص إلى صوت",
        Description = "تحويل النصوص المكتوبة إلى صوت باستخدام تقنيات الذكاء الاصطناعي المتقدمة.",
        Active = true,
        Image = "/chatbot-03.png",  // يمكن تغيير صورة البطاقة هنا
        SubscriptionsPlans = plans
    },
    new ContainerPlansModel
    {
        Id = "2",
        Name = "تحويل النص إلى لهجة",
        Description = "تحويل النص إلى لهجة محددة بدقة عالية.",
        Active = true,
        Image = "/chatbot-03.png",  // يمكن تغيير صورة البطاقة هنا
        SubscriptionsPlans = plans
    },
    new ContainerPlansModel
    {
        Id = "3",
        Name = "روبوت تفاعلي (API)",
        Description = "دمج روبوت تفاعلي من خلال API للعديد من المهام.",
        Active = true,
        Image = "/chatbot-03.png",  // يمكن تغيير صورة البطاقة هنا
        SubscriptionsPlans = plans
    }
};




        }
        public async Task<IEnumerable<PlansContainerModel>?> getAllContainersAsync()
        {

            return new List<PlansContainerModel>{
                new PlansContainerModel
                {
                    Id = "1",
                    Name = "Basic Plan",
                    Description = "This is a basic plan with minimal features.",
                    Price = 19.99m,
                    ImageUrl = "/ai-hand.png",

                },
                new PlansContainerModel
                {
                    Id = "2",
                    Name = "Standard Plan",
                    Description = "This is a standard plan with more features.",
                    Price = 49.99m,
                    ImageUrl = "/ai-hand.png",

                },
                new PlansContainerModel
                {
                    Id = "3",
                    Name = "Premium Plan",
                    Description = "This is a premium plan with all features.",
                    Price = 99.99m,
                    ImageUrl = "/ai-hand.png",


                }
         };
        }


        public List<SubscriptionPlanModel> GetBasicSubscriptionsPlansAR()
        {
            return new List<SubscriptionPlanModel>
            {
                    new SubscriptionPlanModel
                    {
                        Id = "1",
                        Name = "Free",
                        Description = "خطة اشتراك أساسية",
                        Active = true,
                        Price = 0m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 9.99m,
                        ContainerId = "1",
                        TotalBilling = 119.88m,
                        Image = "basic-plan.png",
                        MonthlyPrice = 9.99m,
                        AnnualPrice = 99.99m,
                        WeeklyPrice = 2.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "عدد النماذج AI", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "الطلبات", Description = "1,000 طلب", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "المعالج", Description = "مشترك", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "الذاكرة العشوائية", Description = "2 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "السرعة", Description = "2 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "الدعم", Description = "لا", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "تخصيص", Description = "لا", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "لا", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = false },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "1", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },

                        }
                    },
                    new SubscriptionPlanModel
                    {
                        Id = "2",
                        Name = "Standard",
                        Description = "خطة اشتراك متوسطة",
                        Active = true,
                        Price = 29.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 29.99m,
                        ContainerId = "2",
                        TotalBilling = 359.88m,
                        Image = "standard-plan.png",
                        MonthlyPrice = 29.99m,
                        AnnualPrice = 299.99m,
                        WeeklyPrice = 7.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "عدد النماذج AI", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "الطلبات", Description = "10,000", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "المعالج", Description = "2 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "الذاكرة العشوائية", Description = "2 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "السرعة", Description = "1 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "الدعم", Description = "لا", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "تخصيص", Description = "لا", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "3", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "10", Name = "قابلية التوسع", Description = "مرتين شهرياً", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                        }
                    },
                    new SubscriptionPlanModel
                    {
                        Id = "3",
                        Name = "Professional",
                        Description = "خطة اشتراك احترافية",
                        Active = true,
                        Price = 49.99m,
                        IsFixed = false,
                        IsPaid = true,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 49.99m,
                        ContainerId = "3",
                        TotalBilling = 599.88m,
                        Image = "professional-plan.png",
                        MonthlyPrice = 49.99m,
                        AnnualPrice = 499.99m,
                        WeeklyPrice = 12.49m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "عدد النماذج AI", Description = "12", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "الطلبات", Description = "100,000", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "المعالج", Description = "4 جيجا بايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "الذاكرة العشوائية", Description = "8 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "السرعة", Description = "0.5 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "الدعم", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "7", Name = "تخصيص", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "10", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                              new PlanFeatureModel { Id = "10", Name = "قابلية التوسع", Description = "غير محدد", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                        }
                    },
                     new SubscriptionPlanModel
    {
        Id = "4",
        Name = "Enterprise",
        Description = "خطة اشتراك متقدمة للمؤسسات",
        Active = true,
        Price = 99.99m,
        IsFixed = false,
        IsPaid = true,
        Quantity = 1,
        BillingPeriod = "Monthly",
        TotalAmount = 99.99m,
        ContainerId = "4",
        TotalBilling = 1199.88m,
        Image = "advanced-plan.png",
        MonthlyPrice = 99.99m,
        AnnualPrice = 999.99m,
        WeeklyPrice = 24.99m,
        Features = new List<PlanFeatureModel>
        {
            new PlanFeatureModel { Id = "1", Name = "عدد النماذج AI", Description = "12", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "الطلبات", Description = "غير محدد", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "المعالج", Description = "غير محدد", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "الذاكرة العشوائية", Description = "غير محدد", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "السرعة", Description = "0.5 pre/Second", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "الدعم", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "7", Name = "تخصيص", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "نعم", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "غير محدد", BillingPeriod = "شهري", TotalAmount = 9.99m, Active = true },
                           
        }
    }
                // Add other plans similarly...
            }; ;
   

        }
        public async Task<IEnumerable<ContainerPlansModel>?> getAllAsync()
        {
          

            return db;
        }

        public async Task<ContainerPlansModel?> getOneAsync(string containerId)
        {

            return db.FirstOrDefault(x=>x.Id== containerId) ??null;
        }

        public async Task<List<SubscriptionPlanModel>?> getSubscriptionsPlansAsync(string containerId)
        {

            return db.FirstOrDefault(x => x.Id == containerId)?.SubscriptionsPlans??null;
        }

        public async Task<List<SubscriptionPlanModel>?> getAllSubscriptionsPlansAsync()
        {

            return GetBasicSubscriptionsPlansAR();
            //var subscriptionPlans = db.Where(x => x.SubscriptionsPlans != null && x.SubscriptionsPlans.Any())
            //                          .SelectMany(x => x.SubscriptionsPlans)
            //                          .ToList();

            //return subscriptionPlans;
        }

        public async Task<List<PlanFeatureModel>?> getSubscriptionsPlansFeaturesAsync(string planId)
        {
            foreach (var item in db)
            {
                var plan = item?.SubscriptionsPlans?.FirstOrDefault(X => X.Id == planId);
                if (plan!=null && plan.Id==planId)
                    return plan.Features??null;
            }
            return  null;
        }
        public async Task<SubscriptionPlanModel?> getOneSubscriptionPlanAsync(string planId)
        {
            foreach (var item in db)
            {
                var plan = item?.SubscriptionsPlans?.FirstOrDefault(X => X.Id == planId);
                if (plan != null)
                {
                    return plan;
                }
            }
            return null;
        }




    }
}
