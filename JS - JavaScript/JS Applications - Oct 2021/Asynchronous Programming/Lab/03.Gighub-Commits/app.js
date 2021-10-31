async function loadCommits() {
    const commitsUl = document.querySelector('#commits');
    commitsUl.replaceChildren();
    const user = document.querySelector('#username').value;
    const repo = document.querySelector('#repo').value;

    try {
        const res = await fetch(`https://api.github.com/repos/${user}/${repo}/commits`);

        if(res.status != 200){
            throw new Error(`${res.status}:${res.statusText}`);
        }
        
        const data = await res.json();
        console.log(data);
        data.forEach(commit => {
            const liElement = document.createElement('li');
            liElement.textContent = `${commit.commit.author.name}: ${commit.commit.message}`;

            commitsUl.appendChild(liElement);
        });

    } catch (error) {
        const errorLi = document.createElement('li');
        errorLi.textContent = `Error: ${error.message} (Not Found)`;
        commitsUl.appendChild(errorLi);
    }
}