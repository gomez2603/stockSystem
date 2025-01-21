import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
export const bearerInterceptor: HttpInterceptorFn = (req, next) => {
 
  const authService = inject(AuthService);
  const token = authService.getToken();  

  if (token) {
    const bearerReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    return next(bearerReq);
  }
  return next(req);
};