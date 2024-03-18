CREATE TABLE courses (
     course_id serial PRIMARY KEY,
     name_course text NOT null,
     price double precision not null,
     CONSTRAINT price_name_course CHECK (price > 0 AND name_course <> '')
);

insert into courses (name_course, price) values ('C# Базовый', 50000);
insert into courses (name_course, price) values ('C# Продвинутый', 100000);
insert into courses (name_course, price) values ('Шаблоный проектирование', 70000);
insert into courses (name_course, price) values ('Frontend Angular', 150000);
insert into courses (name_course, price) values ('Frontend React', 130000);