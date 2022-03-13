
# GitHub Users Repository

A .NET Framework, ASP NET MVC project used to search for users on GitHub.

There are 2 pages within the application. One for Search and one for Details of a returned user.

[Unity](https://www.nuget.org/packages/Unity/) has been used for dependency injection.

Within the Services, calls are made to the GitHub API using the standard `System.Net.Http.HttpClient`.

`GithubUsernameAttribute` is a custom validation attribute, created to meet all requirements of a GitHub username(taken from sign-up page).

Have not used Ajax for this scenario. Could well have done,  but with the spec only referencing 2 pages (Search and Results), I decided to stick with a stricly MVC based approach.
## Run Locally

Clone the project

```bash
  git clone https://github.com/mjwork/GitHubUsersRepository.git
```

Once downloaded, run the application. You will be presented with a Search page where you may search for a GitHub user.
## Other

Small piece of regex used on the username search: `(-)\1{1,}`

This just matches on hyphens where there are more than 1 next to each other e.g. (--)
