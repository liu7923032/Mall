
var abp = abp || {};

(function () {
    if (!layer) {
        abp.log.error("不存在layer")
    }

    console.log(layer);
    /* DEFAULTS *************************************************/
    //toastr.options.positionClass = 'toast-bottom-right';

    /* NOTIFICATION *********************************************/

    var showNotification = function (type, message, title, options) {
        //toastr[type](message, title, options);

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

        layer.alert({
            title: title,
            content: message,
            type: 1,
            icon: iconValue
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

