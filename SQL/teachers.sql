CREATE TABLE teachers (
     teacher_id serial PRIMARY KEY,
     name_teacher varchar(40) NOT null,
     grade integer NOT null
);

insert into teachers (name_teacher, grade) values ('Иванов Алексей', 1);
insert into teachers (name_teacher, grade) values ('Баранов Пётр', 2);
insert into teachers (name_teacher, grade) values ('Ошибко Сергей', 3);
insert into teachers (name_teacher, grade) values ('Петров Иван', 4);
insert into teachers (name_teacher, grade) values ('Алексеев Артём', 5);