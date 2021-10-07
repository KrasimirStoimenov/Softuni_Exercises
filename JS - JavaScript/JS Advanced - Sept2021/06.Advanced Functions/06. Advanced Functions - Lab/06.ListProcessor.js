function commandProccessor(array) {
    const result = [];

    for (const command of array) {
        let [func, string] = command.split(' ');

        createCommand(func, string);
    }

    function createCommand(func, string) {
        if (func == 'add') {
            result.push(string);
        }
        else if (func == 'remove') {
            let index = result.indexOf(string);
            while (index != -1) {
                result.splice(index, 1);
                index = result.indexOf(string);
            }

        }
        else {
            console.log(result.join(','));
        }
    }
}



commandProccessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);

commandProccessor(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);