var addTodoBtn = document.getElementById('add-todo');
var textarea = document.getElementById('the-textarea');
var todoList = document.getElementById('todo-list');
var showHideTodoBtn = document.getElementById('show-hide-todo');

addTodoBtn.addEventListener('click', function () {
    if (textarea.value !== '') {
        var li = document.createElement('li');
        var deleteBtn = document.createElement('button');
        var text = document.createTextNode(textarea.value);

        deleteBtn.innerHTML = 'Delete todo';
        li.appendChild(deleteBtn);
        li.appendChild(text);
        todoList.appendChild(li);

        deleteBtn.addEventListener('click', function () {
            deleteBtn.parentElement.parentElement.removeChild(deleteBtn.parentElement);
        });

        textarea.value = '';
    }
});

showHideTodoBtn.addEventListener('click', function () {
    if (todoList.style.display !== 'none') {
        todoList.style.display = 'none';
    } else {
        todoList.style.display = '';
    }

    console.log('show hide')
});