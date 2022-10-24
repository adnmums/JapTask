import { BrowserRouter, Route, Routes } from "react-router-dom";
import Sidebar from "./components/Sidebar";
import Students from "./pages/Students/Students";
import Programs from "./pages/Programs";
import Selections from "./pages/Selections/Selections";
import AddStudent from "./pages/Students/AddStudent";
import Login from "./pages/Login";
import HomePage from "./pages/HomePage";
import StudentProfile from "./pages/StudentProfile";
import AdminReport from "./pages/AdminReport";
import EditStudent from "./pages/Students/EditStudent";

import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import AdminRoute from "./utils/AdminRoute";
import StudentRoute from "./utils/StudentRoute";

function App() {
  return (
    <>
      <BrowserRouter>
        <Sidebar>
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/login" element={<Login />} />
            <Route
              path="/students"
              element={
                <AdminRoute>
                  <Students />
                </AdminRoute>
              }
            />
            <Route
              path="/add"
              element={
                <AdminRoute>
                  <AddStudent />
                </AdminRoute>
              }
            />
            <Route
              path="/edit"
              element={
                <AdminRoute>
                  <EditStudent />
                </AdminRoute>
              }
            />
            <Route
              path="/report"
              element={
                <AdminRoute>
                  <AdminReport />
                </AdminRoute>
              }
            />
            <Route path="/programs" element={<Programs />} />
            <Route path="/selections" element={<Selections />} />
            <Route
              path="/profile"
              element={
                <StudentRoute>
                  <StudentProfile />
                </StudentRoute>
              }
            />
          </Routes>
        </Sidebar>
      </BrowserRouter>
      <ToastContainer hideProgressBar={true} />
    </>
  );
}

export default App;
