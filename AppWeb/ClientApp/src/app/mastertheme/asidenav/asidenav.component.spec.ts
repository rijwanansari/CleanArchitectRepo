import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AsidenavComponent } from './asidenav.component';

describe('AsidenavComponent', () => {
  let component: AsidenavComponent;
  let fixture: ComponentFixture<AsidenavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AsidenavComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AsidenavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
