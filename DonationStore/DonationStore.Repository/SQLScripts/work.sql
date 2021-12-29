
select * from sys.tables
select * from aspnetusers
select * from don

select * from DonationImages
AspNetUserClaims
AspNetUserLogins
AspNetUserTokens
AspNetRoleClaims
AspNetUserRoles

select * from Donations d join DonationImages on d.id = donationId join aspnetusers a on d.UserId = a.Id

update aspnetusers set PhoneNumber =  '' where id = 'de50f0ed-e1fd-4b81-a9cb-c62cb684dbb4'

-- update donations set description ='O Discman foi o primeiro portátil leitor de CDs, mídias que durante algum tempo foram top de linha quando o assunto era qualidade digital de áudio.' where id = 'E9D0252B-209A-451F-581B-08D9AE968929'

--delete from DonationImages where id = '41288F85-592A-4149-9272-08D9B21EA934'
-- delete aspnetusers where email = 'pkdesouza@gmail.com'


select a2.Name 'doador', d.Title, a.Name, * from DonationAcquisition ad 
join aspnetusers a on a.Id = ad.userId
join Donations d on d.Id = ad.DonationId
join aspnetusers a2 on a2.Id = d.UserId

select * from aspnetusers where id = '6a5b0aad-b59e-4130-bfb8-5b614a728610'

--update DonationAcquisition set Status = 2 where id = '354D1BF6-20B7-4C11-35A3-08D9B2B688B1'

--update Donations set status = 4 where id in ('E9D0252B-209A-451F-581B-08D9AE968929','12B47DC7-1698-4587-581C-08D9AE968929','1A37C013-20BE-445F-581D-08D9AE968929')