# 가상 및 증강 현실 프로그래밍 README

## 가상하냥 조
- **인공지능학과 2021035323 최선아**
- **인공지능학과 2021071185 신수연**
- **산업경영공학과 2019038768 백윤성**
- **컴퓨터학부 2018037356 안동현**

## 주제
잃어버린 안산 산업의 역사로 인해 존재가 사라져가는 안산 산업 역사 박물관을 구하는 어드벤처 형식 교육용 VR 게임

## 주 사용자
**초등학생**

박물관 프로그램이 주로 저 연령층을 대상으로 하고, 실제 박물관 주 고객이 어린 가족 단위이거나 현장 체험학습이므로 초등학교 저학년을 대상으로 쉽게 이해할 수 있도록 제작.

## 게임 시나리오 개요
플레이어는 안산 산업 역사 박물관을 방문하여 박물관 정령 "아니"와 함께 사라진 안산의 산업 역사를 되찾기 위해 과거로 여행한다. 미니게임을 통해 "산업의 정수"를 모으고, 마지막에는 모든 것을 훔친 정령 "무리"를 설득하여 역사를 복원한다.

## 게임 흐름
- **로비** > **스테이지** > **미니게임** > **정수 획득**
<img width="588" alt="image" src="https://github.com/bysxx/project-v/assets/91772497/0a1d62f0-bfb2-4df7-8615-2d7f4531257c">

## 스테이지 및 미니게임

**스테이지1 – 자동차 산업**
- **미니게임1 – 자동차 조립하기:** 떨어진 부품들을 Ray Interactor와 Grip 버튼으로 조립.
<img width="574" alt="image" src="https://github.com/bysxx/project-v/assets/91772497/5631c26f-334e-4bba-8f4c-bed84a597a87">

- **미니게임2 – 자동차 운전하기:** 왼쪽 컨트롤러의 Joy Stick으로 정해진 코스를 따라 운전.
<img width="582" alt="image" src="https://github.com/bysxx/project-v/assets/91772497/590ca276-de13-447a-91f8-44ecadfd7995">

**스테이지2 – 전기 전자 산업**
- **미니게임1 – 채널 돌리기:** Direct Interactor와 Grip 버튼으로 채널 맞추기.
<img width="530" alt="image" src="https://github.com/bysxx/project-v/assets/91772497/a0107a46-9f07-41fa-812b-9b6eb97b4c78">

- **미니게임2 – 전화 걸어보기:** Ray Interactor와 Grip 버튼으로 전화번호 입력.
<img width="485" alt="image" src="https://github.com/bysxx/project-v/assets/91772497/4b6fc3bf-8e21-42c0-957a-6f4e4bc41135">

**보스 스테이지**
- **패턴1 – 몰려오는 적 막기:** Grip 버튼으로 총을 잡고 Trigger 버튼으로 적 웨이브 막기.
<img width="468" alt="image" src="https://github.com/bysxx/project-v/assets/91772497/276f1d77-c42e-4a27-8167-370eccebc933">

- **패턴2 – 퀴즈 풀기:** 정답 탄환을 Grip 버튼으로 잡고 총에 장전해 보스에게 데미지 입히기.
<img width="388" alt="image" src="https://github.com/bysxx/project-v/assets/91772497/44111568-9447-44fc-bebb-268f4745236e">


**메인 메뉴**
- 시작
- 조작 방법
- 게임 종료

**로비 씬**
- 각 스테이지 연결 + 스토리

## 기능 차트(구)
![323319752-c07dfcb5-1e1e-455d-99af-0e79d33403b5](https://github.com/bysxx/project-v/assets/87707867/b50e5de7-f96f-4774-b83c-45ccdf503f22)

## 시스템 사용법

| 시스템  | 문서 |
|--------|------|
| 액션 등록 | [Action Based document.pdf](https://github.com/user-attachments/files/15901944/Action.Based.document.pdf) |
| 컨트롤러 이벤트 | [Controller function document.pdf](https://github.com/user-attachments/files/15901949/Controller.function.document.pdf) |
| 대화 시스템 | [Dialogue System document.pdf](https://github.com/user-attachments/files/15901951/Dialogue.System.document.pdf) |
| 상호작용 방법 | [Interaction Setting document.pdf](https://github.com/user-attachments/files/15901952/Interaction.Setting.document.pdf) |
| 퀘스트 시스템 | [Quest System document.pdf](https://github.com/user-attachments/files/15901954/Quest.System.document.pdf) |
| XR Interaction Toolkit 사용법 | [ToolKit Basic document.pdf](https://github.com/user-attachments/files/15901956/ToolKit.Basic.document.pdf) |
| 튜토리얼 시스템 | [Tutorial System Document.pdf](https://github.com/user-attachments/files/15901958/Tutorial.System.Document.pdf) |


## 사용 기술/스택

**Tools**
- Unity: 게임 및 VR/AR 앱 개발을 위한 통합 개발 환경(IDE)
- Github: 버전 관리 및 협업 도구
- Git LFS: 큰 용량의 파일 관리 도구
- Notion: 문서 관리 도구

**Library**
- XR Interaction Toolkit

**Stack**
- C#: Unity에서 사용되는 주요 프로그래밍 언어 (게임 로직 및 상호작용 구현)
- Unity API: 유니티 엔진 제공 다양한 API 사용하여 VR/AR 앱 개발

## 역할 분배

| 이름   | 역할 | 메일 |
|--------|------|-----|
| 안동현  | 게임 시스템(대화, 퀘스트, 스토리 진행, 튜토리얼, UI 기능), 로비 기능, 보스 기능,  리뷰 씬, 메인메뉴 씬, 스테이지 2 기능 수정, 시스템 도큐먼트 작성, 규칙 도큐먼트 작성, 게임 전체 연결, 빌드, 영상 제작, 전체 UI 제작, 이펙트 제작, 퀴즈 제작, NPC 제작, 범용 매니저 스크립트 제작, 대화 제작, 퀘스트 제작, 게임 메인 기획, 스토리 메인 기획, 플로우 차트 제작, 맵 최적화 |  fblood53@gmail.com |
| 백윤성  | 스테이지 1-1 기능, 스테이지 1 퀘스트 구현, git(PR) 관리, 일정 관리, 프로젝트 전체 관리 | 0415white@gmail.com |
| 최선아  | 스테이지 2-2 기능, 스테이지 2-2 퀘스트 구현, 스테이지 2 NPC 대화, 에셋 서치, 보고서 작성, 발표 | dondo0412@gmail.com |
| 신수연  | 스테이지 1-2 기능(+퀘스트 연결), 스테이지 2-1 기능 구현, 보고서 작성, 발표 | gnsqj0408@gmail.com |


# Commit Convention
- feat: 새로운 기능을 추가
- fix: 버그 수정
- design: CSS 등 사용자 UI 디자인 변경
- style: 코드 포맷 변경, 세미 콜론 누락, 코드 수정이 없는 경우
- refactor:	프로덕션 코드 리팩토링
- comment: 필요한 주석 추가 및 변경
- docs:	문서 수정
- test:	테스트 코드, 리펙토링 테스트 코드 추가, Production Code(실제로 사용하는 코드) 변경 없음
- chore:	빌드 업무 수정, 패키지 매니저 수정, 패키지 관리자 구성 등 업데이트, Production Code 변경 없음

위 키워드와 함께 커밋에 관한 간단한 얘기를 아래와 영어로 같이 작성
- 예) feat: update ani model

# Branch 전략
feature 단위로 분기를 만들고 수시로 main 브랜치에 PR을 통해 머지후 브랜치 제거
- 에) feature/ani-model -> main merge
