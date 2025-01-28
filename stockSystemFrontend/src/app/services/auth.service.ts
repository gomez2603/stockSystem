import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);
  private  apiUrl = environment.apiUrl+'user';
  private currentUserSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public currentUser: Observable<any> = this.currentUserSubject.asObservable();


  constructor() {
    // Verificar si existe un token y un usuario guardado en localStorage

    const savedToken = localStorage.getItem('token');
    
    if ( savedToken) {
      const decodedUser = this.decodeToken(savedToken);
      this.currentUserSubject.next(decodedUser);
    }
  }

  login(credentials: { username: string; password: string }): Observable<any> {
    return this.http
      .post<any>(this.apiUrl+'/login', credentials, {
      })
      .pipe(
        catchError((error) => {
          console.error('Error de login', error);
          throw error;
        })
      );
  }

  saveUserSession(response: any): void {
    localStorage.setItem('token', response.token);
    const decodedToken = this.decodeToken(response.token);
  
    // Actualizar el BehaviorSubject con los datos decodificados del token
    this.currentUserSubject.next(decodedToken);
  }

  logout(): void {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    this.currentUserSubject.next(null);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLogged(): boolean {
    const currentUser = this.currentUserSubject.value;
    console.log(this.currentUserSubject.value)
    // Verificar si el currentUser y la fecha de expiración están disponibles
    if (!currentUser || !currentUser.exp) {
      console.log("Fuera")
      return false; // Si no hay usuario o la fecha de expiración no está presente, el usuario no está logueado
    }

    // Obtener el tiempo actual en segundos
    const currentTime = Math.floor(Date.now() / 1000);

    // Verificar si el token ha expirado
    if (currentUser.exp <= currentTime) {
      console.log("Token Expirado",currentTime)
      this.logout(); // Si el token ha expirado, cerrar sesión
      return false;
    }

    return true;
  }

  getRoles(): string[] {
    const currentUser = this.currentUserSubject.value;
    return currentUser?.roles ? [currentUser.roles] : []; // Devuelve un array con los roles del usuario
  }

  hasRole(role: string): boolean {
    const roles = this.getRoles();
    return roles.includes(role); // Verifica si el usuario tiene el rol especificado
  }


  private decodeToken(token: string): any {
    try {
      // Dividir el token en sus tres partes (Header, Payload, Signature)
      const payload = token.split('.')[1];
      const decodedPayload = atob(payload); // Decodificar el payload de Base64
      return JSON.parse(decodedPayload); // Parsear el payload a un objeto
    } catch (error) {
      console.error('Error al decodificar el token:', error);
      return null;
    }
  }
}
