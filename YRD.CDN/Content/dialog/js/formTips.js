/**
 * 内容：表单---提示信息内容
 * 时间：2016-10-09
 * 作者：马英武
 */
(function(w){
	var defaultJson = {

		obj : null,
		dir : "bottom",
		str : "通过验证",
		icon : true,
		pos : false,
		className : "a",
		html : null

	} 
	var tips = {

		init : function(){

		},
		success : function(json){
			var json = json || defaultJson;

			if(json.pos){
				json.className = json.className + " p_success";
			}else{
				json.className = json.className + " success";
			}

			this.create(json, "s");

		},
		error : function(json){
			var json = json || defaultJson;
			if(json.pos){
				json.className = json.className + " p_error";
			}else{
				json.className = json.className + " error";
			}

			this.create(json, "e");

		},
		warning : function(json){
			var json = json || defaultJson;

			if(json.pos){
				json.className = json.className + " p_warning";
			}else{
				json.className = json.className + " warning";
			}
			
			this.create(json, "w");

		},

		create : function(json, type){			

			$(".tip").remove();

			var oDiv = $("<div ele = 'tips' class = 'tip'></div>");

			if(json.pos){
				
				oDiv.css("position", "absolute")
				oDiv.addClass(json.dir)
			
			}

			json.className && oDiv.addClass(json.className);

			if(!json.html || !json.html.length){
				json.str = '<em title = "'+ json.str +'">'+ json.str +'</em>';
				switch(type){
					case "w" : 
						json.pos && (json.str = "<i class = 'arrows'></i>" + json.str);
						json.icon && (json.str = "<i class = 'fa fa-warning'></i>" + json.str);
						break;
					case "s" :
						json.pos && (json.str = "<i class = 'arrows'></i>" + json.str);
						json.icon && (json.str = "<i class = 'fa fa-check-circle'></i>" + json.str);
						break;
					case "e" :
						json.pos && (json.str = "<i class = 'arrows'></i>" + json.str);
						json.icon && (json.str = "<i class = 'fa fa-times-circle'></i>" + json.str);
						break;
				}
				
			}else{
				json.str = json.html
			}						

			oDiv.html( json.str )

			this.add(json, oDiv);

		},

		add : function(json, tipsObj){
			if(json.pos){
				json.obj.parent().css("position", "relative");
			}
			switch(json.dir){

				case "bottom" :

					json.obj.next().hasClass("tip") ? json.obj.next().remove() : "";

					json.obj.after(tipsObj);

					break;
				case "top" :
					json.obj.prev().hasClass("tip") ? json.obj.prev().remove() : "";

					json.obj.before(tipsObj);

					break;
				case "right" :
					json.obj.next().hasClass("tip") ? json.obj.next().remove() : "";

					tipsObj.css("display", "inline-block");

					json.obj.after(tipsObj);
					break;
				case "left" :
					json.obj.prev().hasClass("tip") ? json.obj.prev().remove() : "";

					tipsObj.css("display", "inline-block");

					json.obj.before(tipsObj);
					break;

			}

		},
		remove : function(){
			$("div[ele = 'tips']").remove();
		}

	}

	w.tips = tips

})(window)








