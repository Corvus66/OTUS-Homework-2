CREATE TABLE teachers (
     teacher_id serial PRIMARY KEY,
     name_teacher varchar(40) NOT null,
     grade integer NOT null
);

insert into teachers (name_teacher, grade) values ('������ �������', 1);
insert into teachers (name_teacher, grade) values ('������� ϸ��', 2);
insert into teachers (name_teacher, grade) values ('������ ������', 3);
insert into teachers (name_teacher, grade) values ('������ ����', 4);
insert into teachers (name_teacher, grade) values ('�������� ����', 5);