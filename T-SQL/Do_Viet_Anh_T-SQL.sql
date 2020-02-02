--                       T-SQL                                
USE new_data;
GO 
--1 thêm cột tên khách hàng vào bảng thanh toán 
ALTER TABLE THANHTOAN ADD TENKHACHHANG nvarchar(50);
GO
ALTER TABLE THANHTOAN
DROP TENKHACHHANG
--2 xóa nhóm món ăn có mã nhóm =1
DELETE NHOMMONAN WHERE MANHOM = 1
GO

--3 Cập nhật tên món, đơn giá của món ăn có mã món  =6
UPDATE MONAN SET DONGIA = 40000, TENMON= N'lẩu tứ xuyên'
WHERE MAMON=6
go
--4 Tìm bàn của 1 khách hàng có mã bàn = 9 xem thẻ có được nhân viên phục vụ hay không?
--  Nếu ID_MANHANVIEN = 0 -> bàn ko có nhân viên phục vụ
--  Nếu ID_MANHANVIEN khác 0 -> bàn có nhân viên phục vụ

IF (SELECT BANAN.ID_MANHANVIEN FROM BANAN WHERE BANAN.MABAN = 9) < 1
BEGIN
    PRINT N'bàn ko có nhân viên phục vụ.'
END
ELSE
	BEGIN
		PRINT N'bàn đã có nhân viên phục vụ.'
	END

--5 Tìm xem trong bảng khachhang có khách hàng nào có tên là hiếu hay không?

IF EXISTS (SELECT * FROM KHACHHANG WHERE TENKHACHHANG LIKE N'%Hiếu%')
BEGIN
    PRINT N'Có khách hàng tên Hiếu:'
	(SELECT * FROM KHACHHANG WHERE TENKHACHHANG LIKE N'%Hiếu%')
END
ELSE
BEGIN
	PRINT N'Không có khách hàng nào tên Hiếu'
END

go

--6 in ra thanh toán của khách hàng và phần giảm giá trong evant của cửa hàng 
select MAKHACHHANG,KHACHHANG.TENKHACHHANG,MAYEUCAU,TONGTIEN ,[% được giảm]=
CASE
	WHEN TONGTIEN <20000 THEN 10
	WHEN TONGTIEN BETWEEN 20000 and 50000 THEN 15
	WHEN TONGTIEN BETWEEN 50000 and 1000000 THEN 20
	ELSE
		0.0
	END
from KHACHHANG,YEUCAU,THANHTOAN
where KHACHHANG.MAKHACHHANG=YEUCAU.ID_MAKHACHHANG
      and YEUCAU.MAYEUCAU=THANHTOAN.ID_MAYEUCAU
	  order by TONGTIEN asc
GO
--7 đếm số hóa đơn trong ngày 14

declare @SoHoaDon int
declare @Ngay datetime
set @Ngay ='2019-10-14'
Select @SoHoaDon = Count(MATHANHTOAN) From THANHTOAN where NGAYTT='2019-10-14'
print N' Số hóa đơn là : '+Convert(Nvarchar(10),@SoHoaDon)
print N' Ngày = '+Cast(@Ngay as NVarchar(20))
Go

--8 thông tin món ăn được yêu cầu
declare @ThongTinMonAn table(
[tên món] nvarchar(50) not null ,
[mã món] int not null,
[số lượng] int not null,
[trạng thái] nvarchar(50) not null ,
[thành tiền] int not null
);
insert into @ThongTinMonAn
select
(select TENMON from MONAN where DONGYEUCAU.ID_MAMON = MONAN.MAMON ),
(select MAMON from MONAN where DONGYEUCAU.ID_MAMON = MONAN.MAMON),
(select SOLUONG from DONGYEUCAU where DONGYEUCAU.ID_MAMON = MONAN.MAMON),
(select TRANGTHAI from DONGYEUCAU where DONGYEUCAU.ID_MAMON = MONAN.MAMON),
(select THANHTIEN from DONGYEUCAU where DONGYEUCAU.ID_MAMON = MONAN.MAMON)
from DONGYEUCAU,MONAN
where DONGYEUCAU.ID_MAMON = MONAN.MAMON

select * 
from @ThongTinMonAn

--9 cursor  ( truyền giá dựa vào tổng tiền nếu >50000 thì trạng thái là 3
--										nếu <50000 và >30000 thì trạng thái là 2
--										còn lại thì 1 
--           từ đó biết nhân viên nào thanh toán được hóa đơn lớn hơn để tăng lương)


DECLARE TANGLUONGCursor CURSOR FOR SELECT TONGTIEN ,ID_MANHANVIEN  FROM THANHTOAN

OPEN TANGLUONGCursor

DECLARE @ID_MANHANVIEN CHAR(100)
DECLARE @TONGTIEN NVARCHAR(100)
FETCH NEXT FROM TANGLUONGCursor INTO @ID_MANHANVIEN,@TONGTIEN
WHILE @@FETCH_STATUS = 0
BEGIN
	IF @TONGTIEN > 50000
	BEGIN
		PRINT 'ID:' + Cast(@ID_MANHANVIEN as NVarchar(20))
        PRINT 'TRANG THAI:TOT ' 
	END
	ELSE 
	IF @TONGTIEN < 50000 AND @TONGTIEN > 30000 
	BEGIN
		PRINT 'ID:' + Cast(@ID_MANHANVIEN as NVarchar(20))
        PRINT 'TRANG THAI:KHA '
	END
	ELSE
	BEGIN
		PRINT 'ID:' + Cast(@ID_MANHANVIEN as NVarchar(20))
        PRINT 'TRANG THAI:TB '
	END
    

	FETCH NEXT FROM TANGLUONGCursor INTO @ID_MANHANVIEN,@TONGTIEN    
END
CLOSE TANGLUONGCursor
DEALLOCATE TANGLUONGCursor

--10 tạo function để xác định trả về tình trạng của bàn ăn có mã bàn là 3   

CREATE FUNCTION trangthaiban(@trangthai int)
returns nvarchar(50)
as
begin
declare @thongtin nvarchar(50)
if @trangthai=0 
set @thongtin = N'bàn chưa được đặt'
else 
set @thongtin = N'bàn đã được đặt'
return @thongtin
END
GO
select MABAN,LOAIBAN,dbo.trangthaiban(TINHTRANG)
from BANAN
where MABAN=3
GO
--11 trigger
/* cập nhật hàng trong kho sau khi đặt hàng hoặc cập nhật */
CREATE TRIGGER trg_DatHang ON DONGYEUCAU AFTER INSERT AS 
BEGIN
	UPDATE MONAN
	SET SoLuongTon = SoLuongTon - (
		SELECT SoLuongDat
		FROM inserted
		WHERE MaHang = tbl_KhoHang.MaHang
	)
	FROM tbl_KhoHang
	JOIN inserted ON tbl_KhoHang.MaHang = inserted.MaHang
END
GO
/* cập nhật hàng trong kho sau khi cập nhật đặt hàng */
CREATE TRIGGER trg_CapNhatDatHang on tbl_DatHang after update AS
BEGIN
   UPDATE tbl_KhoHang SET SoLuongTon = SoLuongTon -
	   (SELECT SoLuongDat FROM inserted WHERE MaHang = tbl_KhoHang.MaHang) +
	   (SELECT SoLuongDat FROM deleted WHERE MaHang = tbl_KhoHang.MaHang)
   FROM tbl_KhoHang 
   JOIN deleted ON tbl_KhoHang.MaHang = deleted.MaHang
end
GO
/* cập nhật hàng trong kho sau khi hủy đặt hàng */
create TRIGGER trg_HuyDatHang ON tbl_DatHang FOR DELETE AS 
BEGIN
	UPDATE tbl_KhoHang
	SET SoLuongTon = SoLuongTon + (SELECT SoLuongDat FROM deleted WHERE MaHang = tbl_KhoHang.MaHang)
	FROM tbl_KhoHang 
	JOIN deleted ON tbl_KhoHang.MaHang = deleted.MaHang
END

--12 Transaction
