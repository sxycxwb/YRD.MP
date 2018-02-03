using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using YRD.CDN;
namespace YRD.Web
{
    public class ShopPayPasswordHelper
    {
        public static Base CheckPassword(string shopid, string password)
        {
            Base b = new Base();
            try
            {
                using (var db = new EFContext())
                {
                    var paypassword = MD5.GetMD5(password, "");
                    var f = db.selshoppaypassword.FirstOrDefault(x => x.ShopID == shopid && x.PayPassword == paypassword);
                    if (f != null)
                    {
                        b.Code = 1;
                        b.Message = "支付密码输入正确";
                    }
                    else
                    {
                        b.Code = 0;
                        b.Message = "支付密码输入错误";
                    }
                }
            }
            catch (Exception Exc)
            {

                b.Code = 0;
                b.Message = ConstantHelper.Failure;
            }

            return b;
        }
    }



}