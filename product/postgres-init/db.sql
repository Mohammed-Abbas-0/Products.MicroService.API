-- init_postgres.sql
-- يُنفّذ داخل قاعدة البيانات التي أنشأها Docker (ecommerceusers)

-- enable uuid generator for gen_random_uuid()
CREATE EXTENSION IF NOT EXISTS "pgcrypto";

-- Users table
CREATE TABLE IF NOT EXISTS users (
    userid UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    personname VARCHAR(100),
    email VARCHAR(150) UNIQUE,
    password VARCHAR(255),
    gender VARCHAR(20),
    created_at TIMESTAMPTZ DEFAULT now()
);

-- Insert example (مشفّر بكريت — أمن أفضل من plain text)
-- امسح سطر الـ crypt واستخدم القيمة مباشرة
INSERT INTO users (userid, personname, email, password, gender)
VALUES (
    gen_random_uuid(),
    'Mohammed Abbas',
    'mohammed@example.com',
    '123456', -- نص عادي ومباشر للتجربة
    'Male'
)
ON CONFLICT (email) DO NOTHING;
ON CONFLICT (email) DO NOTHING;
