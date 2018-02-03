/**
 * 内容：正则库
 * 作者：马英武
 * 时间：2016-09-07
 */

var reg_lib = {

	// 检验非法字符   					true --> 非法字符			  false --> 不是非法字符
	noNorm : 		/[`~!！@#$%^&*()_+<>?:"{},.\/;'[\]]/im,	

	// 检验邮箱是否正确  				true --> 邮箱正确			  false --> 邮箱错误
	email : 		/^(\w-*.*)+@(\w-?)+(.\w{2,})+$/,

	// 检验手机号						true --> 正确 				  false --> 错误
	phoneNum : 		/^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$/,

	// 检验身份证号						true --> 正确 				  false --> 错误
	ID_15 : /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/,
	ID_18 : /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/,

	// 用户名--注册
	username_r :    /^[A-Za-z0-9_\-\u4e00-\u9fa5]+$/,

	// 检验密码							true --> 正确 				  false --> 错误
	password :      function(num1, num2){
		var reg = new RegExp("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{"+ (num1?num1:6) + "," + (num2?num2:20) +"}$");
		return reg;
	},

	// 检验只能是数字
	number : 		function(num){
		var reg = null;
		num ? reg = new RegExp("^[0-9]{"+ num +"}$") : reg = new RegExp("^[0-9]*$")
		return reg
	},

	// 检验只能是数字和字母
	num_word : /^[\d+a-zA-Z]+$/,

	// 检验是否包含数字
	hasNum : 		/\d+/,

	// 检验是否包含字母
	hasWord : 		/[a-zA-Z]/,

	// 检验是否包含中文
	hasChina : 		/[\u4e00-\u9fa5]/,

	// 检验是否有空格
	hasSpace : 		/\s/g,

	// 检验邮政编码
	hasPostalCode : /^[0-9]{6}$/,


}




















