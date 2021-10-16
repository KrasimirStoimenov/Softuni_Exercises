(function stringExtension() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this;
        }
        return this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        }
        return this.toString();
    };

    String.prototype.isEmpty = function () {
        return this.length == 0;
    };

    String.prototype.truncate = function (n) {
        if (n <= 3) {
            return ".".repeat(n);
        }

        if (this.length <= n) {
            return this.toString();
        }
        else {
            let lastIndex = this.substr(0, n - 2).lastIndexOf(" ");
            if (lastIndex != -1) {
                return this.substr(0, lastIndex) + "...";
            } else {
                return this.substr(0, n - 3) + "...";
            }
        }
    };

    String.format = function (string, ...params) {

        for (var i = 0; i < params.length; i++) {
            string = string.replace(/\{\d\}/, params[i]);
        }
        return string;
    }
})();

// let str = 'my string'
// console.log(str = str.ensureStart('my'));
// console.log(str = str.ensureStart('hello '));
// console.log(str = str.truncate(16));
// console.log(str = str.truncate(14));
// console.log(str = str.truncate(8));
// console.log(str = str.truncate(4));
// console.log(str = str.truncate(2));
// console.log(str = String.format('The {0} {1} fox', 'quick', 'brown'));
// console.log(str = String.format('jumps {0} {1}', 'dog'));

let asd = 'quick brown fox jumps over the lazy dog';
console.log(asd);
var ans = asd.ensureStart('the ');
console.log(ans);
ans = ans.ensureStart('the ');
console.log(ans);
