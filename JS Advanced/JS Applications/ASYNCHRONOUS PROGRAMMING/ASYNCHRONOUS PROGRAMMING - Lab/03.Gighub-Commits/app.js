function loadCommits() {
    const username = document.getElementById('username').value;
    const repository = document.getElementById('repo').value;

    const url = `https://api.github.com/repos/${username}/${repository}/commits`

    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error(` ${response.status} (Not Found)`);

            }
            return response.json();
        })
        .then(data => {
            const ul = document.getElementById('commits');
            ul.innerHTML = '';
            
            data.forEach(r => {
                const li = document.createElement('li');

                li.textContent = `${r.commit.author.name}: ${r.commit.message}`;
                ul.appendChild(li);
            });

        })
        .catch(error => {
			const ule = document.getElementById('commits');
            ule.innerHTML = '';
            const lie = document.createElement('li');
            lie.textContent = error;
			ule.appendChild(lie);
		});
}