/*首页统计图*/
$(function(){
    var myChart = echarts.init(document.getElementById('indexStatistic'));
    var option = {
        title:{
            text:'本月营收',
            textStyle:{
                fontSize:16
            },
            left:'center'
        },
        tooltip:{
            trigger:'axis',
            axisPointer:{
                type:'cross'
            }
        },
        legend:{
            top:50,
            right:10,
            orient:'vertial',
            data:[
                {
                    name:'总收入'
                },
                '现金',
                '刷卡',
                '支付宝'
            ]
        },
        xAxis:{
            data:['1','2','3','4','5','6','7','8','9','10','11','12','13','14','15','16','17','18','19','20','21','22','23','24','25','26','27','28','29','30']
        },
        yAxis:{},
        series:[
            {
                name:'总收入',
                type:'line',
                symbol:'rect',
                label:{
                    normal:{
                        show:true
                    }
                },
                itemStyle:{
                    normal:{
                        color:'#fea610'
                    }
                },
                data:[520,540,560,870,650,635,541,500,580,680,690,670,850,845,770,880,780,851,658,688,756,712,700,550,560,550,550,550,560,580]
            },
            {
                name:'现金',
                type:'line',
                data:[200,240,250,214,321,412,325,120,320,220,220,250,260,320,350,351,330,330,350,380,344,336,120,190,110,180,170,150,240,220]
            },
            {
                name:'刷卡',
                type:'line',
                data:[85,95,99,78,62,100,120,150,120,110,210,220,260,88,80,90,100,150,160,120,80,70,60,55,66,55,85,75,85,96]
            },
            {
                name:'支付宝',
                type:'line',
                data:[235,200,201,500,470,100,250,350,85,540,65,120,550,330,440,352,110,254,125,189,126,250,355,452,256,152,566,252,265,255]
            }
        ]
    };
    myChart.showLoading(
        'default',
        {
            text: '加载中',
            color: '#f60',
            textColor: '#000',
            maskColor: 'rgba(255, 255, 255, 0.8)',
            zlevel: 0
        }
    );
    setTimeout(function(){
        myChart.hideLoading();
        myChart.setOption(option);
    },1000);

});