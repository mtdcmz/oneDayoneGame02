#!/bin/bash
# 用法：在 Git Bash 中执行 ./deploy.sh

echo "=== GitHub 部署脚本 ==="

# 1. 检查是否已有远程仓库
if git remote get-url origin > /dev/null 2>&1; then
    echo "检测到已存在远程仓库 origin，将直接使用。"
else
    read -p "请输入你的 GitHub 仓库地址（例如 https://github.com/用户名/仓库名.git）: " REPO_URL
    if [ -z "$REPO_URL" ]; then
        echo "错误：未输入仓库地址，退出。"
        exit 1
    fi
    git init
    git remote add origin "$REPO_URL"
    echo "远程仓库已添加。"
fi

# 2. 创建或覆盖 .gitignore（Unity 专用）
cat > .gitignore << EOF
/[Ll]ibrary/
/[Tt]emp/
/[Oo]bj/
/[Bb]uild/
/[Bb]uilds/
/[Ll]ogs/
/[Uu]ser[Ss]ettings/
*.csproj
*.unityproj
*.sln
*.user
*.userprefs
*.pidb
*.booproj
*.svd
*.pdb
*.mdb
*.opendb
*.VC.db
.DS_Store
EOF
echo ".gitignore 已生成。"

# 3. 添加所有文件（不包括被忽略的）
git add .

# 4. 提交
read -p "请输入提交信息（默认：'首次提交'）: " COMMIT_MSG
if [ -z "$COMMIT_MSG" ]; then
    COMMIT_MSG="首次提交"
fi
git commit -m "$COMMIT_MSG"

# 5. 推送
echo "正在推送到远程仓库..."
# 获取当前分支名
CURRENT_BRANCH=$(git branch --show-current)
if [ -z "$CURRENT_BRANCH" ]; then
    # 如果还没有分支，默认用 main
    CURRENT_BRANCH="main"
fi
git push -u origin "$CURRENT_BRANCH"

echo "✅ 完成！请前往 GitHub 仓库 Settings > Pages 配置分支和文件夹。"