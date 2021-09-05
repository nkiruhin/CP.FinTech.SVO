const authProvider = {
  login: ({ username }) => {
    localStorage.setItem("auth", JSON.stringify(username));
    return Promise.resolve();
  },
  checkAuth: ({ params }) => {
    let email = localStorage.getItem("auth");
    if (email) return Promise.resolve();
    else return Promise.reject();
  },
  logout: () => Promise.resolve(),
  getPermissions: params => Promise.resolve(),
};

export default authProvider;
