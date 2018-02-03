using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YRD.Dao;
using System.Diagnostics;
using Com.Alipay;
using LitJson;
using System.Threading.Tasks;
using YRD.Model;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace YRD.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFileService()
        {
            string url = string.Format("http://sms.yrd.com/api/Sms/PostSendSMSWithVerificationCode");
            var http = HttpClientHelper.GetClient();
            {
                var response = http.PostAsJsonAsync(url, new PaSms() { Phone = "1321" }).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<Base>(response.Content.ReadAsStringAsync().Result);
                   
                }
                else
                {
                    new Base();
                }
            }

        }

        [TestMethod]
        public void TestInitDefaultRole()
        {
            using (var db = new EFContext())
            {

                var role1011 = new selrole()
                {
                    ID = "1011",
                    Title = "云掌柜",
                    Introduction = "云掌柜(免费版)",
                    CreateManagerID = "",
                    CreateTime = DateTime.Now,
                    IsAvailable = 1,
                    IsDefault = 1,
                    ShopID = "",
                    Sort = 0
                };
                var role1021 = new selrole()
                {
                    ID = "1021",
                    Title = "云掌柜",
                    Introduction = "云掌柜(微店版)",
                    CreateManagerID = "",
                    CreateTime = DateTime.Now,
                    IsAvailable = 1,
                    IsDefault = 1,
                    ShopID = "",
                    Sort = 0
                };
                var role1031 = new selrole()
                {
                    ID = "1031",
                    Title = "云掌柜",
                    Introduction = "云掌柜(聚餐版)",
                    CreateManagerID = "",
                    CreateTime = DateTime.Now,
                    IsAvailable = 1,
                    IsDefault = 1,
                    ShopID = "",
                    Sort = 0
                };
                var role1041 = new selrole()
                {
                    ID = "1041",
                    Title = "云掌柜",
                    Introduction = "云掌柜(宴会版)",
                    CreateManagerID = "",
                    CreateTime = DateTime.Now,
                    IsAvailable = 1,
                    IsDefault = 1,
                    ShopID = "",
                    Sort = 0
                };
                var role1012 = new selrole()
                {
                    ID = "1012",
                    Title = "云掌柜",
                    Introduction = "云掌柜(免费版+云库存)",
                    CreateManagerID = "",
                    CreateTime = DateTime.Now,
                    IsAvailable = 1,
                    IsDefault = 1,
                    ShopID = "",
                    Sort = 0
                };
                var role1022 = new selrole()
                {
                    ID = "1022",
                    Title = "云掌柜",
                    Introduction = "云掌柜(微店版+云库存)",
                    CreateManagerID = "",
                    CreateTime = DateTime.Now,
                    IsAvailable = 1,
                    IsDefault = 1,
                    ShopID = "",
                    Sort = 0
                };
                var role1032 = new selrole()
                {
                    ID = "1032",
                    Title = "云掌柜",
                    Introduction = "云掌柜(聚餐版+云库存)",
                    CreateManagerID = "",
                    CreateTime = DateTime.Now,
                    IsAvailable = 1,
                    IsDefault = 1,
                    ShopID = "",
                    Sort = 0
                };
                var role1042 = new selrole()
                {
                    ID = "1042",
                    Title = "云掌柜",
                    Introduction = "云掌柜(宴会版+云库存)",
                    CreateManagerID = "",
                    CreateTime = DateTime.Now,
                    IsAvailable = 1,
                    IsDefault = 1,
                    ShopID = "",
                    Sort = 0
                };

                List<selrole> list = new List<selrole>();
                list.Add(role1011);
                list.Add(role1012);
                list.Add(role1021);
                list.Add(role1022);
                list.Add(role1031);
                list.Add(role1032);
                list.Add(role1041);
                list.Add(role1042);

                foreach (var item in list)
                {
                    //先删除默认角色数据
                    var queryrole = db.selrole.FirstOrDefault(x => x.ID == item.ID);
                    if (queryrole != null)
                    {
                        db.selrole.Remove(queryrole);
                    }

                    var queryrolepemit = db.selrole_pemit.Where(x => x.SelRoleID == item.ID);
                    if (queryrolepemit.Any())
                    {
                        db.selrole_pemit.RemoveRange(queryrolepemit);
                    }
                    db.SaveChanges();
                }


                {
                    var selrolemodel = role1011;
                    db.selrole.Add(selrolemodel);
                    var queryrolepemit = db.selpemit.Where(x => x.PemitState.Contains("1")).ToList();
                    foreach (var item in queryrolepemit)
                    {
                        db.selrole_pemit.Add(new selrole_pemit() { ID = WebTools.getGUID(), SelRoleID = selrolemodel.ID, SelPemitID = item.ID });
                    }
                    db.SaveChanges();
                }

                {
                    var selrolemodel = role1012;
                    db.selrole.Add(selrolemodel);
                    var queryrolepemit = db.selpemit.Where(x => x.PemitState.Contains("1") || x.PemitState.Contains("6")).ToList();
                    foreach (var item in queryrolepemit)
                    {
                        db.selrole_pemit.Add(new selrole_pemit() { ID = WebTools.getGUID(), SelRoleID = selrolemodel.ID, SelPemitID = item.ID });
                    }
                    db.SaveChanges();
                }


                {
                    var selrolemodel = role1021;
                    db.selrole.Add(selrolemodel);
                    var queryrolepemit = db.selpemit.Where(x => x.PemitState.Contains("2")).ToList();
                    foreach (var item in queryrolepemit)
                    {
                        db.selrole_pemit.Add(new selrole_pemit() { ID = WebTools.getGUID(), SelRoleID = selrolemodel.ID, SelPemitID = item.ID });
                    }
                    db.SaveChanges();
                }

                {
                    var selrolemodel = role1022;
                    db.selrole.Add(selrolemodel);
                    var queryrolepemit = db.selpemit.Where(x => x.PemitState.Contains("2") || x.PemitState.Contains("6")).ToList();
                    foreach (var item in queryrolepemit)
                    {
                        db.selrole_pemit.Add(new selrole_pemit() { ID = WebTools.getGUID(), SelRoleID = selrolemodel.ID, SelPemitID = item.ID });
                    }
                    db.SaveChanges();
                }

                {
                    var selrolemodel = role1031;
                    db.selrole.Add(selrolemodel);
                    var queryrolepemit = db.selpemit.Where(x => x.PemitState.Contains("3")).ToList();
                    foreach (var item in queryrolepemit)
                    {
                        db.selrole_pemit.Add(new selrole_pemit() { ID = WebTools.getGUID(), SelRoleID = selrolemodel.ID, SelPemitID = item.ID });
                    }
                    db.SaveChanges();
                }

                {
                    var selrolemodel = role1032;
                    db.selrole.Add(selrolemodel);
                    var queryrolepemit = db.selpemit.Where(x => x.PemitState.Contains("3") || x.PemitState.Contains("6")).ToList();
                    foreach (var item in queryrolepemit)
                    {
                        db.selrole_pemit.Add(new selrole_pemit() { ID = WebTools.getGUID(), SelRoleID = selrolemodel.ID, SelPemitID = item.ID });
                    }
                    db.SaveChanges();
                }


                {
                    var selrolemodel = role1041;
                    db.selrole.Add(selrolemodel);
                    var queryrolepemit = db.selpemit.Where(x => x.PemitState.Contains("4")).ToList();
                    foreach (var item in queryrolepemit)
                    {
                        db.selrole_pemit.Add(new selrole_pemit() { ID = WebTools.getGUID(), SelRoleID = selrolemodel.ID, SelPemitID = item.ID });
                    }
                    db.SaveChanges();
                }

                {
                    var selrolemodel = role1042;
                    db.selrole.Add(selrolemodel);
                    var queryrolepemit = db.selpemit.Where(x => x.PemitState.Contains("4") || x.PemitState.Contains("6")).ToList();
                    foreach (var item in queryrolepemit)
                    {
                        db.selrole_pemit.Add(new selrole_pemit() { ID = WebTools.getGUID(), SelRoleID = selrolemodel.ID, SelPemitID = item.ID });
                    }
                    db.SaveChanges();
                }

            }

        }




        [TestMethod]
        public void Testselcardfreeid()
        {
            var v = SafeCodeHelper.GetSafeCode;


            Task t = new Task(Do);
            t.Start();
            t.Wait();

        }

        void Do()
        {
            using (var db = new EFContext())
            {
                for (int i = 1; i <= 9999; i++)
                {
                    selcardfreeid f = new selcardfreeid()
                    {
                        CardID = string.Format("{0}{1}{2}{3}", "6688", "2017", "2032", i.ToString().PadLeft(4, '0')),
                        Remark = "2017"
                    };
                    db.selcardfreeid.Add(f);
                    db.SaveChanges();
                    Debug.WriteLine(i);
                }

            }
        }

        [TestMethod]
        public void TestSendRSA()
        {
            var smsParam = "{\"name\":\"peiandsky\",\"age\":28}";
            JsonData jsonData = JsonMapper.ToObject(smsParam);
            foreach (KeyValuePair<string, JsonData> item in jsonData)
            {
                var i = item;

            }

        }





        [TestMethod]
        public void TestSendSMS()
        {
            //var v = Type.GetType("YRD.Dao.selshop");
            //using (var db=new EFContext())
            //{
            //  var vv=  db.Find(v, "966257");
            //}
            //var type = typeof(YRD.Dao.selshop);

            // var v = DB.selshopsmschange.ConfirmShopVersionByBatchId("5f9dc38f-2b67-4744-9ec5-d6bc7602c517");
            // var v1 = DB.selshopversion.Value.ConfirmShopVersionByBatchId("f77a350f752b4dce9ee6fc9af7cf9db3");

            // var v = DB.selshopmoneyrecharge.ConfirmAddRechargeByBatchId("0b6b617e-9cc7-4cbf-8ada-076176a9469101");

            //var vv = v;

            // SendSMS.SMSHelper.SendSMS("18603458099", "3456");
        }



        public class People
        {
            public Nullable<int> X { get; set; }
            public Nullable<int> Y { get; set; }

        }
        [TestMethod]
        public void TestMethodNewtonsoft()
        {
            List<People> list = new List<People>();
            list.Add(new People() { X = 1, Y = 1 });
            list.Add(new People() { X = 2, Y = 2 });
            list.Add(new People() { X = 5, Y = null });


            string s = string.Empty;
            if (s.IsNull())
            {

            }
            if (string.IsNullOrEmpty(s))
            {

            }
            int? i = null;
            if (i.HasValue)
            {

            }
        }
        [TestMethod]
        public void TestMethod()
        {
            using (var db = new EFContext())
            {

                try
                {
                    var q = from s in db.selmanager
                            join d in db.selmanagerdetail on s.ID equals d.ID into _d
                            from __d in _d.DefaultIfEmpty()
                            select new
                            {
                                s.ID,
                                s.LoginName,
                                QQ = __d.QQ == null ? "" : __d.QQ,
                                yy = __d == null ? "" : __d.AddressInfo
                            };

                    var l = q.ToList();
                }
                catch (Exception Exc)
                {

                }



                //var v = db.selcard.ToList();

                //var time1 = DateTime.Now;
                //var x = db.selcard.ToList();
                //var time2 = DateTime.Now;
                //var x2 = db.selprinter.Where(a => a.Title != "3321").ToList();
                //var time3 = DateTime.Now;

                //var time4 = DateTime.Now;
                //Debug.WriteLine((time2 - time1).ToString());
                //Debug.WriteLine((time3 - time2).ToString());
                //Debug.WriteLine((time4 - time3).ToString());
                //LogHelper.Debug((time2 - time1).ToString());
                // return Content(time1 + "  " + (time4 - time1).ToString() + "    " + DateTime.Now);



                // DateTime dt1 = DateTime.Now;

                //var v= db.Database.ExecuteSqlCommand("insert into cususer(ID, LoginName) values(next value for MYCATSEQ_USERSGLOBAL, '"+WebTools.getGUID()+"') ; select @@IDENTITY");

                // DateTime dt2 = DateTime.Now;

                // TimeSpan ts = dt2 - dt1;






            }
        }
    }
}
