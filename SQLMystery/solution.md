# [The SQL Murder Mystery](https://mystery.knightlab.com/)
## Part 1: Find the killer
### Read the crime report to learn about witnesses
```SQL
select *
from crime_scene_report
where city = 'SQL City'
and date = 20180115
and type = 'murder'
```
### Information about both witnesses and their testimonies
```SQL
with first_witness as (
  select id 
  from person
  where name like 'Annabel%'
  and address_street_name = 'Franklin Ave'
), second_witness as (
  select id
  from person
  where address_street_name = 'Northwestern Dr'
  order by address_number desc
  limit 1
), witnesses as (
  select * from first_witness_id
  union
  select * from second_witness_id
)

select i.transcript
from interview i
join witnesses w
on i.person_id = w.id
```
### Filtering out killer based on clues in testimonies
```SQL
select p.name
from person p
join drivers_license dl
on dl.id = p.license_id
join get_fit_now_member mem
on mem.person_id = p.id
join get_fit_now_check_in che
on che.membership_id = mem.id
where dl.plate_number like '%H42W%'
and mem.id like '48Z%'
and mem.membership_status = 'gold'
and che.check_in_date = 20180109
```
## Part 2: Find the mastermind
### Killer's testimony
```SQL
select *
from interview
where person_id = 67318;
```
### Filtering the mastermind
```SQL
with symphony_attendance as (
  select person_id
  from facebook_event_checkin
  where date between 20171201 and 20171231
  and event_name = 'SQL Symphony Concert'
  group by person_id
  having count(*) >= 3
)

select p.name, i.annual_income
from drivers_license dl
join person p
on p.license_id = dl.id
join income i
on i.ssn = p.ssn
join symphony_attendance sa
on sa.person_id = p.id
where dl.car_make = 'Tesla'
and dl.car_model = 'Model S'
and dl.gender = 'female'
and dl.hair_color = 'red'
and dl.height between 65 and 67
order by i.annual_income desc;
```
