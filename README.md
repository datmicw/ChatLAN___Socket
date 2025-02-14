# <h1 style="text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5);">💬 Chat LAN - Socket (WinForms)</h1>

<p style="font-size: 18px;">Ứng dụng chat LAN đơn giản sử dụng <b>C#, .NET WinForms, và Socket TCP</b>.</p>

## 📌 <h2 style="text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);">Tính năng chính</h2>

<ul>
  <li>💻 Chat giữa <b>các máy trong cùng mạng LAN</b>.</li>
  <li>🎨 <b>Giao diện WinForms đơn giản</b>, dễ sử dụng.</li>
  <li>🚀 Gửi và nhận tin nhắn theo thời gian thực bằng <b>TCP Socket</b>.</li>
  <li>🔗 <b>Client-Server Model</b>: Một Server có thể nhận nhiều Client.</li>
</ul>

---

## 🛠 <h2 style="text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);">Hướng dẫn cài đặt</h2>

### **1️⃣ Chạy Server**
1. Mở **Visual Studio**.
2. Mở **`ChatServer`** và chạy **`Program.cs`**.
3. Server sẽ lắng nghe kết nối trên **cổng 5000**.
4. Nếu thành công, console sẽ hiển thị:
   ```bash
   Server đang chạy trên cổng 5000...
   
### **2️⃣ Chạy Client**
1. Mở **`ChatClient`** (WinForms).
2. Chỉnh sửa file `Chat.cs` → Đặt đúng **địa chỉ IP của Server**:
```csharp
client = new TcpClient("192.168.1.100", 5000);

// Lấy địa chỉ IP bằng cách:
// Mở CMD → nhập: ipconfig → tìm mục IPv4
client = new TcpClient("192.168.1.5", 5000); // Kết nối đến server
