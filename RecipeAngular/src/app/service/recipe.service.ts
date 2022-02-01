import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Recipe } from '../models/Recipe';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })
  export class RecipeService {
    
    baseUrl = `${environment.urlPrincipal}/api/Recipes`;
  
    constructor(private http: HttpClient) { }
  
    getAll(): Observable<Recipe[]>{
      return this.http.get<Recipe[]>(`${this.baseUrl}`)
    }
  
    getById(id: number): Observable<Recipe>{
      return this.http.get<Recipe>(`${this.baseUrl}/${id}`)
    }
  
    post(recipe: Recipe){
      return this.http.post(`${this.baseUrl}`, recipe);
    }
    put(recipe: Recipe){
      return this.http.put(`${this.baseUrl}/${recipe.id}`, recipe);
    }
  
    delete(id: number){
      return this.http.delete(`${this.baseUrl}/${id}`)
    }
  }
