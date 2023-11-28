import { Routes } from '@angular/router';
import { TeacherLoginComponent } from './components/teacher-login/teacher-login.component';
import { TeacherLayoutsComponent } from './components/teacher-layouts/teacher-layouts.component';
import { TeacherHomeComponent } from './components/teacher-home/teacher-home.component';
import { TeacherStudentsComponent } from './components/teacher-students/teacher-students.component';
import { TeacherExamsComponent } from './components/teacher-exams/teacher-exams.component';

export const routes: Routes = [
    {
        path: "teacher-login",
        component: TeacherLoginComponent
    },
    {
        path: "teacher",
        component: TeacherLayoutsComponent,
        children: [
            {
                path: "",
                component: TeacherHomeComponent
            },
            {
                path: "students",
                component: TeacherStudentsComponent
            },
            {
                path: "exams",
                component: TeacherExamsComponent
            }
        ]
    }
];
