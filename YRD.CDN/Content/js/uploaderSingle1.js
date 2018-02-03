//单个图片上传
jQuery(function() {
    var $ = jQuery,
        $list = $('#fileListSingle1'),
        s  = $list.attr('data-size'),
    // 优化retina, 在retina下这个值是2
        ratio = window.devicePixelRatio || 1,
    // 缩略图大小
        thumbnailWidth = 100 * ratio,
        thumbnailHeight = 100 * ratio,
    // Web Uploader实例
        uploader;


    // 初始化Web Uploader
    uploader = WebUploader.create({
        // 选完文件后，是否自动上传。
        auto: false,
        // swf文件路径
        swf: 'js/Uploader.swf',
        // 文件接收服务端。
        server: '',
        // 选择文件的按钮。可选。
        // 内部根据当前运行是创建，可能是input元素，也可能是flash.
        pick: '#filePickerSingle1',
        // 只允许选择图片文件。
        accept: {
            title: 'Images',
            extensions: 'gif,jpg,jpeg,bmp,png',
            mimeTypes: 'image/*'
        },
        //最大上传的文件数量, 总文件大小,单个文件大小(单位字节);
        fileNumLimit: 1,
        fileSizeLimit: s * 1024 * 1024,
        fileSingleSizeLimit: s * 1024 * 1024
    });

    // 当有文件添加进来的时候
    uploader.on('fileQueued', function (file) {
        var $li = $(
                '<div id="' + file.id + '" class="file-item thumbnail">' +
                '<img>' +
                '<a class="trash" href="javascript:;"></a>' +
                '<div class="modal-backdrop"><div class="showImg"><img/><a href="javascript:;" class="closed"></a></div></div>' +
                '</div>'
            ),
            $img = $li.find('img');
        // $list为容器jQuery实例
        $list.append($li);
        // 创建缩略图
        // 如果为非图片文件，可以不用调用此方法。
        // thumbnailWidth x thumbnailHeight 为 100 x 100
        uploader.makeThumb(file, function (error, src) {
            if (error) {
                $img.replaceWith('<span>不能预览</span>');
                return;
            }
            $img.attr('src', src);
        }, thumbnailWidth, thumbnailHeight);

    });
    //显示删除图标，并删除选中文件
    $list.on('click', 'a.trash', function (e) {
        e.preventDefault();
        var file = $(this).parent().attr('id');
        $(this).parent().remove();
        uploader.removeFile(file);
    });
    //点击图片，查看大图
    $list.on('click', '.file-item>img', function () {
        $(this).siblings('.modal-backdrop').show();
    });
    $list.on('click', '.modal-backdrop a.closed', function (e) {
        e.preventDefault();
        $(this).parent().parent().hide();
    });
    //选择文件错误触发事件;
    uploader.on('error', function( code ) {
        var text = '';
        switch( code ) {
            case  'F_DUPLICATE' : text = '该图片已经被选择了!' ;
                break;
            case  'Q_EXCEED_NUM_LIMIT' : text = '只能上传一张图片!' ;
                break;
            case  'F_EXCEED_SIZE' : text = '图片大小超过限制，每张图片最大为'+s+'M!';
                break;
            case  'Q_EXCEED_SIZE_LIMIT' : text = '图片总大小超过限制，每张图片最大为'+s+'M!';
                break;
            case 'Q_TYPE_DENIED' : text = '图片类型不正确或者是空文件!';
                break;
            default : text = '未知错误!';
                break;
        }
        alert( text );
    });
});

