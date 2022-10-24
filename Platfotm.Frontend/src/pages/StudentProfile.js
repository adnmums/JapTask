import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getStudentById, reset } from "../features/students/studentsSlice";

import dayjs from "dayjs";

const StudentProfile = () => {
  const dispatch = useDispatch();
  const { user } = useSelector((state) => state.reducer.auth);
  const { studentById } = useSelector((state) => state.students);

  useEffect(() => {
    const data = {
      id: user?.data?.id,
      token: user?.data?.token,
    };
    dispatch(getStudentById(data));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  console.log(studentById);
  return (
    <div>
      <h1>
        {studentById?.data?.firstName} {studentById?.data?.lastName} Profile
      </h1>
      <div style={{ marginTop: "40px" }}>
        <h2>
          Date of Birth:{" "}
          {dayjs(studentById?.data?.birthDate).format("DD/MM/YYYY")}
        </h2>
        <h2>Selection: {studentById?.data?.selection?.title}</h2>
        <h2>Program:{studentById?.data?.selection?.program?.title}</h2>
        <h2>Comments:{studentById?.data?.comments}</h2>
      </div>
    </div>
  );
};

export default StudentProfile;
