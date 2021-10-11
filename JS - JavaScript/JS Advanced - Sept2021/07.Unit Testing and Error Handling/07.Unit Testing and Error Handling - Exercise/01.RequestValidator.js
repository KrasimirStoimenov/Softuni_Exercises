function validator(obj) {
    const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const uriRegex = /^[\w.]+$/;
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const messageRegex = /[<>\\&'"]/;

    if (!obj.method || !methods.includes(obj.method)) {
        throw new Error(`Invalid request header: Invalid Method`)
    }
    else if (!obj.uri || obj.uri == '' || !uriRegex.test(obj.uri)) {
        throw new Error(`Invalid request header: Invalid URI`);
    }
    else if (!obj.version || !versions.includes(obj.version)) {
        throw new Error(`Invalid request header: Invalid Version`);
    }
    else if (obj.message == undefined || messageRegex.test(obj.message)) {
        throw new Error(`Invalid request header: Invalid Message`);
    }

    return obj;
}

// console.log(validator({
//     method: 'GET',
//     uri: 'svn.public.catalog',
//     version: 'HTTP/1.1',
//     message: ''
// }));

// console.log(validator({
//     method: 'OPTIONS',
//     uri: 'git.master',
//     version: 'HTTP/1.1',
//     message: '-recursive'
// }));

// console.log(validator({
//     method: 'POST',
//     uri: 'home.bash',
//     message: 'rm -rf /*'
// }));

console.log(validator({
    method: 'POST',
    version: 'HTTP/2.0',
    message: 'rm -rf /*'
}));