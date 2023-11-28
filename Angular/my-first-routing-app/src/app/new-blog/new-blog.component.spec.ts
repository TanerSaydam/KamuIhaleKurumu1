import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewBlogComponent } from './new-blog.component';

describe('BlogComponent', () => {
  let component: NewBlogComponent;
  let fixture: ComponentFixture<NewBlogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewBlogComponent]
    });
    fixture = TestBed.createComponent(NewBlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
