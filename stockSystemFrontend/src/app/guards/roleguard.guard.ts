import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const roleguardGuard  =  (allowedRoles: string[]): CanActivateFn => {
  return () => {
    const authService = inject(AuthService);

    if (!authService.isLogged()) {
      return false; // Usuario no autenticado
    }

    return allowedRoles.some(role => authService.hasRole(role)); // Verificar si el usuario tiene uno de los roles permitidos
  };
 
  
};
