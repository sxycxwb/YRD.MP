using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class UserAddressCacheModel
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Zipcode { get; set; }
        public int? Province { get; set; }
        public int? City { get; set; }
        public int? Area { get; set; }
        public string Street { get; set; }
        public string OldStreet { get; set; }
        public bool IsDefault { get; set; }
        //Append
        public string ProvinceStr { get; set; }
        public string CityStr { get; set; }
        public string AreaStr { get; set; }
    }
    public class CodeSend
    {
        private string _code; //code

        private int _flag; //flag

        public CodeSend(string Code, int Flag)
        {
            this._code = Code;
            this._flag = Flag;
        }
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        public int Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
    }
    public class CodeName
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CodeNameList
    {
        public List<CodeName> All { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
