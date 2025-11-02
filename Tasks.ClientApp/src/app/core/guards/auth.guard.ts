import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  const loggedInUserEmail = localStorage.getItem('loggedinuser');
  if (loggedInUserEmail != null) {
    return true;
  }

  return router.navigateByUrl('')
};
