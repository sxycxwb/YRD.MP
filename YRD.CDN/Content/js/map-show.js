/*********
 * 地图显示
 * ******/
$(function(){
    var map = new BMap.Map("container");
    map.centerAndZoom("太原", 12);

    //    var txtName = document.getElementById("txtName").value;
    //    map.centerAndZoom(txtName, 12);
    map.enableScrollWheelZoom();    //启用滚轮放大缩小，默认禁用
    map.enableContinuousZoom();    //启用地图惯性拖拽，默认禁用

    map.addControl(new BMap.NavigationControl());  //添加默认缩放平移控件
    map.addControl(new BMap.OverviewMapControl()); //添加默认缩略地图控件
    // map.addControl(new BMap.OverviewMapControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_RIGHT }));   //右下角，打开

    var localSearch = new BMap.LocalSearch(map);
    localSearch.enableAutoViewport(); //允许自动调节窗体大小

    map.addEventListener("click", function (e) {
        document.getElementById("jd").value = e.point.lng;
        document.getElementById("wd").value = e.point.lat;
        //longitude = e.point.lng;
        //latitude = e.point.lat;
        addMarker(e.point);
    });

    function addMarker(point) {  // 创建图标对象
        map.clearOverlays();//清空原来的标注
        var myIcon = new BMap.Icon("../Images/position.png", new BMap.Size(23, 50), { offset: new BMap.Size(10, 25) });
        // 创建标注对象并添加到地图
        //   var marker = new BMap.Marker(point, { icon: myIcon });
        var marker = new BMap.Marker(point);
        map.addOverlay(marker);
    }
    function Shua() {
        var txtName = document.getElementById("txtName").value;
        map.centerAndZoom(txtName, 12);
    }

});
