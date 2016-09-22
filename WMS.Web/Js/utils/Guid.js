/* Created by gang.yang, at 2016-09-20 */
// 生成 Guid, 利用随机数生成 36 位格式的伪 Guid.
// newGuid() 产生新的 Guid.
// empty() 产生空的 Guid.

var Guid = {
    newGuid: function () {
        var guid = "";
        for (var i = 1; i <= 32; i++) {
            var n = Math.floor(Math.random() * 16.0).toString(16);
            guid += n;
            if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                guid += "-";
        }
        return guid;
    },
    empty: function () {
        return "00000000-0000-0000-0000-000000000000";
    }
};