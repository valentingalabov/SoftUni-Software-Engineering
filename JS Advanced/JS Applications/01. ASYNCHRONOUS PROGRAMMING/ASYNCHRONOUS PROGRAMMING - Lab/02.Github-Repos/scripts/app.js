function loadRepos() {
	const username = document.getElementById('username').value;

	const url = `https://api.github.com/users/${username}/repos`;

	fetch(url)
		.then(response => {
			if (response.status == 404) {
				throw new Error("User not found!");
			}

			return response.json();
		})
		.then(data => {

			const ulElement = document.getElementById('repos');
			ulElement.innerHTML = '';
			data.forEach(r => {

				const liElement = document.createElement('li');
				const anc = document.createElement('a');
				anc.href = r.html_url;
				anc.textContent = r.full_name;

				liElement.appendChild(anc);
				ulElement.appendChild(liElement);
			});

		})
		.catch(error => {
			const ul = document.getElementById('repos');
			ul.innerHTML = error;
		});

}