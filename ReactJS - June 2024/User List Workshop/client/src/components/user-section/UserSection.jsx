import UserList from "./user-list/UserList";
import UserAdd from "./user-add/UserAdd"

import { useEffect, useState } from "react";
import UserDetails from "./user-details/UserDetails";

const baseUrl = 'http://localhost:3030/jsonstore'

export default function UserSection() {
    const [users, setUsers] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [fetchError, setFetchError] = useState(false);
    const [showAddUser, setShowAddUser] = useState(false);
    const [showUserDetailsById, setShowUserDetailsById] = useState(null);

    useEffect(() => {
        async function fetchUsers() {
            try {
                const response = await fetch(`${baseUrl}/users`)
                const usersData = await response.json();

                setUsers(Object.values(usersData));
                setFetchError(false);
            } catch (error) {
                setFetchError(true);
            }
            finally {
                setIsLoading(false);
            }
        }

        fetchUsers();
    }, []);

    function addUserClickHandler() {
        setShowAddUser(true);
    }

    function addUserCloseHandler() {
        setShowAddUser(false);
    }

    async function addUserSaveHandler(e) {
        e.preventDefault();

        const formData = new FormData(e.currentTarget);
        const userDataFlatten = { ...Object.fromEntries(formData) };

        const address = {
            country: userDataFlatten.country,
            city: userDataFlatten.city,
            street: userDataFlatten.street,
            streetNumber: userDataFlatten.streetNumber,
        };
        const userData = {
            firstName: userDataFlatten.firstName,
            lastName: userDataFlatten.lastName,
            imageUrl: userDataFlatten.imageUrl,
            email: userDataFlatten.email,
            phoneNumber: userDataFlatten.phoneNumber,
            address: address,
            createdAt: new Date().toISOString(),
            updatedAt: new Date().toISOString(),
        };

        try {
            const response = await fetch(`${baseUrl}/users`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(userData),
            })
            const createdUser = await response.json();

            setUsers(oldUsers => [...oldUsers, createdUser])
            setShowAddUser(false);
        } catch (error) {
            alert(error.message);
        }
    }

    function userDetailsClickHandler(userId) {
        setShowUserDetailsById(userId);
    }

    return (
        <section className="card users-container">

            {/* <!-- Search component --> */}
            <UserList
                users={users}
                isLoading={isLoading}
                fetchError={fetchError}
                onDetails={userDetailsClickHandler}
            />

            {showAddUser && (
                <UserAdd
                    onSave={addUserSaveHandler}
                    onClose={addUserCloseHandler}
                />)}

            {showUserDetailsById && (
                <UserDetails
                    user={users.find(x => x._id === showUserDetailsById)}
                    onClose={() => setShowUserDetailsById(null)}
                />
            )}

            <button className="btn-add btn" onClick={addUserClickHandler}>Add new user</button>

            {/* <!-- Pagination component  --> */}

        </section>
    );
}