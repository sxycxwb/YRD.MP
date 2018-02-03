/**
 * 内容 ：表单验证库
 * 作者 ：马英武
 * 时间 ：2016-09-22
 * 备注 ：如果当前作用域中全局变量 _ 被占用时可以使用 JCheck 进行调用 
 */

(function(w){

	var _ = {
		empty : {
			isEmpty : true,
		},
		// 初始化
		init : function(){
			// 拷贝当前对象下所有属性到 empty 对象中
			for(var attr in _){
				if(attr == "init"){
					continue ;
				}
				_.empty[attr] = function(){

					return _.empty

				}

			}
			// 防止全局变量冲突
			w._ ? w.JCheck = _ : w._ = _

		},
		//用户名( 验证非法字符 ) --- 注册
		reg_name_r : function(str, errorFn){		
			
			var reg = reg_lib.username_r;

			var result = reg.test(str);

			if(!result){

				errorFn && errorFn();

				return _.empty;
			}
			return _;
		},
		// 长度
		reg_length : function(str, minLen, maxLen, errorFn){

			var len = 0;
		    for (var i = 0; i < str.length; i++) {
		        if (str.charCodeAt(i) > 255)
		            len += 2;
		        else
		            len++;
		    }

		    if (len < minLen || len > maxLen) {
		    	errorFn && errorFn();
		        return _.empty;
		    }
		    return _;

		},
		// 是否含有空格
		reg_space : function(str, errorFn){

			var reg = reg_lib.hasSpace;
			reg.lastIndex = 0;
			var result = reg.test(str);

			if(result){
				errorFn && errorFn();
				return _.empty;
			}
			return _;

		},
		// 输入为空字符串
		reg_empty : function(str, errorFn){
			var str = str.trim();
			if(str.length == 0){

				errorFn && errorFn();
				
				return _.empty ;
				
			}

			return _;

		},
		// 两个字符串是否相等 （字符串比对）
		reg_equal : function(str1, str2, errorFn){

			if(str1 != str2){

				errorFn && errorFn();
				return _.empty;

			}

			return _;

		},
		// 手机号码格式
		reg_mobile_format : function(str, errorFn){

			var reg = reg_lib.phoneNum;

			var result = reg.test(str);

			if(!result){
				errorFn && errorFn();
				return _.empty;
			}
			return _;

		},
		// 只能输入数字
		reg_num : function(str, errorFn){

			var reg = reg_lib.number();

			var result = reg.test(str);

			if(!result){
				errorFn && errorFn();
				return _.empty;
			}
			return _;

		},
		// 非法字符
		reg_noNorm : function(str, errorFn){

			var reg = reg_lib.noNorm;

			var result = reg.test(str);

			if( result ){

				errorFn && errorFn();
				return _.empty;

			}
			return _;
		},
		// 只能输入纯字母、纯数字、或者字母和数字组合
		reg_num_word : function(str, errorFn){

			var reg = reg_lib.num_word;

			var result = reg.test(str);

			if( !result ){

				errorFn && errorFn();
				return _.empty;

			}
			return _;

		},
		// 邮箱
		reg_email : function(str, errorFn){

			var reg = reg_lib.email;

			var result = reg.test(str);

			if(!result){
				errorFn && errorFn();
				return _.empty
			}
			return _

		},
		// checkbox
		reg_checkboxRadio : function(jqObj, errorFn){

			var result = null;

			jqObj.each(function(index, ele){

				if($(ele).prop("checked") == true){
					result = true
					return false;

				} 

			});

			if( !result ){
				errorFn && errorFn();
				return _.empty
			}
			return _
			
		},
		// 邮政编码
		reg_postalCode : function(str, errorFn){

			var reg = reg_lib.hasPostalCode;

			var result = reg.test(str);

			if(!result){
				errorFn && errorFn();
				return _.empty;
			}
			return _;
		}

	}

	_.init();

})(window)






















