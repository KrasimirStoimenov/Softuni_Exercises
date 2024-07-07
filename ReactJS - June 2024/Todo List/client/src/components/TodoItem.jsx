import { useState } from "react";

export default function TodoItem({ todo }) {
    const [isCompleted, setIsCompleted] = useState(todo.isCompleted);

    function changeTodoStatusClickHandler() {
        setIsCompleted(!isCompleted);
    }

    return (
        <tr className={`todo ${isCompleted ? 'is-completed' : null}`}>
            <td>{todo.text}</td>
            <td>{isCompleted ? 'Complete' : 'Incomplete'}</td>
            <td className="todo-action">
                <button className="btn todo-btn" onClick={changeTodoStatusClickHandler}>Change status</button>
            </td>
        </tr>
    );
}