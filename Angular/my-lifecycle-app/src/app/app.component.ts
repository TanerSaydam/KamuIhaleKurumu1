import { 
  AfterContentChecked, 
  AfterViewChecked, 
  AfterViewInit, 
  Component, 
  DoCheck, 
  OnDestroy, 
  OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, AfterViewInit, OnDestroy, DoCheck, AfterContentChecked, AfterViewChecked {

  name: string = "";
  names: string[] = [];

  send(){
    this.names.push(this.name)
  }  

  constructor() {
    //Component classı oluşurken çalışır
    console.log("Constructor Çalışıyor....")
  }  

  ngAfterContentChecked(): void {
    //HTML oluşmadan önceden başlıyor ve yapılan her değişiklik algılamasında çalışır
    console.log("AfterContentChecked Çalışıyor....")
  }

  ngAfterViewChecked(): void {
    //HTML oluştuktan sonra yapılan her değişiklik algılamasında çalışır
    console.log("AfterViewChecked Çalışıyor....")
  }

  ngDoCheck(): void {
    //Yapılan herhangi bir değişiklik algılamasında çalışır
    console.log("DoCheck Çalışıyor....")
  }

  ngOnInit(): void {
    //Constructor'dan sonra html olmuşmadan önce çalışır
    console.log("OnInit Çalışıyor....")
  }
  
  ngAfterViewInit(): void {
    //HTML oluştuktan sonra çalışır   
    console.log("After Çalışıyor...");      
  }

  ngOnDestroy(): void {
    //Componentten çıkmak istersem Component yok olur ve bu da o zaman çalışır
    console.log("Destroy çalışıyor...");    
  }
}
