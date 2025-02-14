
# <span style="text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5);">💬 Chat LAN - Socket (WinForms)</span>

Ứng dụng chat LAN đơn giản sử dụng **C#, .NET WinForms, và Socket TCP**.

## 📌 <span style="text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);">Tính năng chính</span>
- 💻 Chat giữa **các máy trong cùng mạng LAN**.
- 🎨 **Giao diện WinForms đơn giản**, dễ sử dụng.
- 🚀 Gửi và nhận tin nhắn theo thời gian thực bằng **TCP Socket**.
- 🔗 **Client-Server Model**: Một Server có thể nhận nhiều Client.

---

## 🛠 <span style="text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);">Hướng dẫn cài đặt</span>

### **1️⃣ Chạy Server**
1. Mở **Visual Studio**.
2. Mở **`ChatServer`** và chạy **`Program.cs`**.
3. Server sẽ lắng nghe kết nối trên **cổng 5000**.
4. Nếu thành công, console sẽ hiển thị:

### **2️⃣ Chạy Client**
1. Mở **`ChatClient`** (WinForms).
2. Chỉnh sửa file `Chat.cs` → Đặt đúng **địa chỉ IP của Server**:
```csharp
client = new TcpClient("192.168.1.5", 5000); // kết nối đến server
