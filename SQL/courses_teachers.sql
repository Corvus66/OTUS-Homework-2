CREATE TABLE courses_teachers (
     courses_teachers_id serial PRIMARY KEY,
     course_id integer NOT null,
     teacher_id integer NOT null,
     FOREIGN KEY (course_id) REFERENCES courses(course_id),
     FOREIGN KEY (teacher_id) REFERENCES teachers(teacher_id)
);

insert into courses_teachers (course_id, teacher_id) values (1, 1);
insert into courses_teachers (course_id, teacher_id) values (2, 2);
insert into courses_teachers (course_id, teacher_id) values (3, 3);
insert into courses_teachers (course_id, teacher_id) values (4, 4);
insert into courses_teachers (course_id, teacher_id) values (5, 5);