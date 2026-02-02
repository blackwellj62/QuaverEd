<template>
  <div>
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <div class="container">
        <RouterLink class="navbar-brand" to="/">QuaverEd</RouterLink>
        <div class="navbar-nav">
          <RouterLink class="nav-link" to="/repositories">Repositories</RouterLink>
        </div>
      </div>
    </nav>

    <router-view />
  </div>
</template>
