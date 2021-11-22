// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const gitUserSrchForm = document.getElementById('gitUserSrch');

gitUserSrchForm.addEventListener('submit', (e) => {

	e.preventDefault();

	let usernameInput = document.getElementById('gitUserInput');
	let gitUsername = usernameInput.value;

	requestUserRepos(gitUsername);

})


function requestUserRepos(username) {

	const xhr = new XMLHttpRequest();

	const url = `https://api.github.com/users/${username}`;

	let bUserFound = false;
	let iCnt = 0;

	xhr.open('GET', url, true);
	xhr.onload = function () {

		const data = JSON.parse(this.response);

		let ul = document.getElementById('userProfile');
		ul.innerHTML = '';

		// Iterate through key value pairs
		for (const [key, value] of Object.entries(data)) {

			iCnt++;

			console.log(`${key}: ${value}`);

			let li = document.createElement('li');

			li.classList.add('list-group-item')
			
			if (key == 'message' && value == 'Not Found') {
				li.innerHTML = '<font color="red">User not found</font>';
			}
			else {
				bUserFound = true;
				li.innerHTML = (`<p><strong>${key}:</strong></br> ${value}</p>`);
				if (iCnt == 1)
					li.innerHTML = li.innerHTML + '<input type="button" value="Add to Favorties"/>';
			}

			ul.appendChild(li);

			if (!bUserFound)
				break;

		}

	}

	xhr.send();

}
