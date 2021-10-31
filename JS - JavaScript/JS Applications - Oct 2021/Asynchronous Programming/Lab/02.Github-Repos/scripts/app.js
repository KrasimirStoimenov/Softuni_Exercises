async function loadRepos() {
	const user = document.querySelector('#username').value;
	const repos = document.querySelector('#repos');
	repos.replaceChildren();
	
	try {
		const res = await fetch(`https://api.github.com/users/${user}/repos`);
		const data = await res.json();

		data.forEach(repo => {
			const liElement = document.createElement('li');
			liElement.innerHTML = `<a href="${repo.html_url}">
			${repo.full_name}
		</a>`;

			repos.appendChild(liElement);
		});
	} catch (error) {
		console.log(error.message);
	}
}