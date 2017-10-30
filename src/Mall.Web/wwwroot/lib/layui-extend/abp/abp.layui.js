
var abp = abp || {};

//abp.notify
(function () {

    console.log(window.layui)
    if (!window.layui) {
        abp.log.error("window.layui 不存在")
        return;
    }

    /* DEFAULTS *************************************************/
    //toastr.options.positionClass = 'toast-bottom-right';

    /* NOTIFICATION *********************************************/

    var showNotification = function (type, message, title, options) {
        //toastr[type](message, title, options);
        layui.use('layer', function () {
            var layer = layui.layer;
            var iconValue = 6;
            switch (type) {
                case "info":
                    iconValue = 6;
                    break;
                case "success":
                    iconValue = 1;
                    break;
                case "warn":
                    iconValue = 0;
                    break;
                case "error":
                    iconValue = 2;
                    break;
            }

            layer.alert(message, {
                title: title,
                //content: message,
                //type: 1,
                icon: iconValue,
                skin: 'layui-layer-lan',
                anim: 4,
                //offset: 'rb'
            });

            //layer.alert('偶吧深蓝style', {
            //    skin: 'layui-layer-lan'
            //    , closeBtn: 0
            //    , anim: 4 //动画类型
            //});
        });
    };


    abp.notify.success = function (message, title, options) {
        showNotification('success', message, title, options);
    };

    abp.notify.info = function (message, title, options) {
        showNotification('info', message, title, options);
    };

    abp.notify.warn = function (message, title, options) {
        showNotification('warning', message, title, options);
    };

    abp.notify.error = function (message, title, options) {
        showNotification('error', message, title, options);
    };
})();

//abp.message
(function () {
    if (!window.layui) {
        abp.log.info("window.layui 未被引用");
        return;
    }

    /* DEFAULTS *************************************************/

    abp.libs = abp.libs || {};
    abp.libs.layuiAlert = {
        config: {
            'default': {

            },
            info: {
                type: 'info'
            },
            success: {
                type: 'success'
            },
            warn: {
                type: 'warning'
            },
            error: {
                type: 'error'
            },
            confirm: {
                type: 'warning',
                title: 'Are you sure?',
                btn: ["confirm", "cancel"],
                success: function () { },
                fail: function () { }
            }
        }
    };

    /* MESSAGE **************************************************/

    var showMessage = function (type, message, title) {
        if (!title) {
            title = message;
            message = undefined;
        }
        var iconValue = 6;
        switch (type) {
            case "info":
                iconValue = 6;
                break;
            case "success":
                iconValue = 1;
                break;
            case "warn":
                iconValue = 0;
                break;
            case "error":
                iconValue = 2;
                break;
        }

        layui.use(["layer", "jquery"], function () {
            var layer = layui.layer;

            layer.msg(message, {
                title: title,
                icon: iconValue,
                time: 4000
            });
        });
    };

    abp.message.info = function (message, title) {
        return showMessage('info', message, title);
    };

    abp.message.success = function (message, title) {
        return showMessage('success', message, title);
    };

    abp.message.warn = function (message, title) {
        return showMessage('warn', message, title);
    };

    abp.message.error = function (message, title) {
        return showMessage('error', message, title);
    };

    abp.message.confirm = function (message, titleOrCallback, callback) {
        var userOpts = {
            content: message
        };

        layui.use(['layer','jquery'], function () {

            var layer = layui.layer;
            var $ = layui.jquery;

            if ($.isFunction(titleOrCallback)) {
                callback = titleOrCallback;
            } else if (titleOrCallback) {
                userOpts.title = titleOrCallback;
            };

            var opts = $.extend(
                {},
                abp.libs.layuiAlert.config.default,
                abp.libs.layuiAlert.config.confirm,
                userOpts
            );

            var index = layer.confirm(message, opts, callback, function () {
               layer.close(index);
            });
        });
        //return $.Deferred(function ($dfd) {
        //    layui.(opts, function (isConfirmed) {
        //        callback && callback(isConfirmed);
        //        $dfd.resolve(isConfirmed);
        //    });
        //});
    };

    abp.event.on('abp.dynamicScriptsInitialized', function () {
        abp.libs.layuiAlert.config.confirm.title = abp.localization.abpWeb('AreYouSure');
        abp.libs.layuiAlert.config.confirm.cancelButtonText = abp.localization.abpWeb('Cancel');
        abp.libs.layuiAlert.config.confirm.confirmButtonText = abp.localization.abpWeb('Yes');
    });

})(jQuery);

