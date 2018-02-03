/*菜品销售统计-销售排行*/
$(function () {
    Highcharts.chart('fss-sale-rank', {
        chart: {
            type: 'column'
        },
        title: {
            text: '菜品销售排行统计'
        },
        xAxis: {
            type: 'category'
        },
        yAxis: {
            title: {
                text: '金额'
            }
        },
        credits:{
            enabled: false
        },
        legend: {
            enabled: false
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: true,
                    format: '{point.y:.1f}%'
                }
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: 占总量的<b>{point.y:.2f}%</b><br/>'
        },
        series: [{
            name: '菜品',
            colorByPoint: true,
            data: [{
                name: '过油肉',
                y: 56.33,
                drilldown: '过油肉'
            }, {
                name: '京酱肉丝',
                y: 24.03,
                drilldown: '京酱肉丝'
            }, {
                name: '水煮鱼',
                y: 10.38,
                drilldown: '水煮鱼'
            }, {
                name: '宫保鸡丁',
                y: 7.77,
                drilldown: '宫保鸡丁'
            }, {
                name: '番茄炒蛋',
                y: 5.91,
                drilldown: '番茄炒蛋'
            }, {
                name: '小菜',
                y: 3.2,
                drilldown: null
            }]
        }],
        drilldown: {
            series: [{
                name: '过油肉',
                id: '过油肉',
                data: [
                    ['Jan', 24.13], ['Feb', 17.2], ['Mar', 8.11], ['Apr', 5.33],
                    ['May', 1.06], ['Jun', 0.5], ['Jul', 17.2], ['Aug', 8.11],
                    ['Sep', 5.33], ['Oct', 1.06], ['Nev', 0.5], ['Dec', 0.5]
                ]
            }, {
                name: '京酱肉丝',
                id: '京酱肉丝',
                data: [
                    ['Jan', 5], ['Feb', 4.32], ['Mar', 3.68], ['Apr', 2.96],
                    ['May', 2.53], ['Jun', 0.5], ['Jul', 1.2], ['Aug', .11],
                    ['Sep', 1.33], ['Oct', 0.6], ['Nev', 0.5], ['Dec', 0.5]
                ]
            }, {
                name: '水煮鱼',
                id: '水煮鱼',
                data: [
                    ['Jan', 5], ['Feb', 4.32], ['Mar', 3.68], ['Apr', 2.96],
                    ['May', 2.53], ['Jun', 0.5], ['Jul', 1.2], ['Aug', .11],
                    ['Sep', 1.33], ['Oct', 0.6], ['Nev', 0.5], ['Dec', 0.5]
                ]
            }, {
                name: '宫保鸡丁',
                id: '宫保鸡丁',
                data: [
                    ['Jan', 5], ['Feb', 4.32], ['Mar', 3.68], ['Apr', 2.96],
                    ['May', 2.53], ['Jun', 0.5], ['Jul', 1.2], ['Aug', .11],
                    ['Sep', 1.33], ['Oct', 0.6], ['Nev', 0.5], ['Dec', 0.5]
                ]
            }, {
                name: '番茄炒蛋',
                id: '番茄炒蛋',
                data: [
                    ['Jan', 5], ['Feb', 4.32], ['Mar', 3.68], ['Apr', 2.96],
                    ['May', 2.53], ['Jun', 0.5], ['Jul', 1.2], ['Aug', .11],
                    ['Sep', 1.33], ['Oct', 0.6], ['Nev', 0.5], ['Dec', 0.5]
                ]
            }]
        }
    });
});
