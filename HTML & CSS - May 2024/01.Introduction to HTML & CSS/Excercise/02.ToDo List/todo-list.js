function toDoList() {
    document.getElementById('add-btn').addEventListener('click', onAdd);

    const todoTasksLiItems = document.querySelectorAll('#todo-tasks li');
    for (const item of todoTasksLiItems) {
        item.addEventListener('click', onDone);
    }
}

function onAdd(ev) {
    const todoTasks = document.getElementById('todo-tasks');
    const inputText = document.querySelector('input[type="text"]');

    if (inputText.value != '') {

        const liElement = document.createElement('li');
        liElement.textContent = inputText.value;
        liElement.addEventListener('click', onDone);
        todoTasks.appendChild(liElement);
        inputText.value = '';
    }
}

function onDone(ev) {
    const tasksDone = document.getElementById('done-tasks');
    tasksDone.appendChild(ev.target);
}