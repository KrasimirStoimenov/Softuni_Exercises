import { useEffect, useState } from "react";
import Spinner from "./Spinner";
import TodoItem from "./TodoItem";

const baseUrl = 'http://localhost:3030/jsonstore';
export default function TodoList() {
    const [todos, setTodos] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        // IIFE function
        (async function fetchTodos() {
            try {
                const response = await fetch(`${baseUrl}/todos`)
                const responseData = await response.json();

                setTodos(Object.values(responseData));
                setIsLoading(false);
            } catch (error) {
                alert(error);
            }
        })();
    }, []);

    return (
        <section className="todo-list-container">
            <h1>Todo List</h1>

            <div className="add-btn-container">
                <button className="btn">+ Add new Todo</button>
            </div>

            <div className="table-wrapper">

                {isLoading && <Spinner />}

                <table className="table">
                    <thead>
                        <tr>
                            <th className="table-header-task">Task</th>
                            <th className="table-header-status">Status</th>
                            <th className="table-header-action">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {todos.map(todo =>
                            <TodoItem
                                key={todo._id}
                                todo={todo}
                            />
                        )}
                    </tbody>
                </table>
            </div>
        </section>
    );
}